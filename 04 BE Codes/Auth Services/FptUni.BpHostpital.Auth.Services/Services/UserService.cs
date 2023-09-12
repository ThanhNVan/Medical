using FptUni.BpHostpital.Auth.Repositories;
using FptUni.BpHostpital.Auth.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FptUni.BpHostpital.Auth.Services;

public class UserService : IUserService
{
    #region [ Fields ]
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IRefreshTokenRepository _refreshToken;
    private readonly JwtSettingModels _jwtSettingModels;
    private readonly ILogger<UserService> _logger;  
    #endregion

    #region [ CTor ]
    public UserService(UserManager<ApplicationUser> userManager,
                        SignInManager<ApplicationUser> signInManager,
                        RoleManager<IdentityRole> roleManager,
                        IRefreshTokenRepository refreshToken,
                        JwtSettingModels jwtSettingModels,
                        ILogger<UserService> logger)
    {
        this._userManager = userManager;
        this._signInManager = signInManager;
        this._roleManager = roleManager;
        this._refreshToken = refreshToken;
        this._jwtSettingModels = jwtSettingModels;
        this._logger = logger;  
    }
    #endregion

    #region [ Methods - Login ]
    public async Task<SignInSuccessModel> SignInAsync(SignInModel model)
    {
        var result = default(SignInSuccessModel);
        var dbResult = await this._signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

        if (!dbResult.Succeeded)
        {
            return result;
        }
        var dbUser = await this._userManager.FindByEmailAsync(model.Email);
        var token = await this.GenerateTokenAsync(dbUser);
        await this.GenerateAndSaveRefreshTokenAsync(token, dbUser.Id);

        result = new SignInSuccessModel();
        result.Email = dbUser.Email;
        result.Fullname = dbUser.Fullname;
        result.AccessToken = token.AccessToken;
        result.RefreshToken = token.RefreshToken;

        return result;
    }
    #endregion

    #region [ Methods - SignUp ]
    public async Task<IdentityResult> SignUpAsync(SignUpModel model)
    {
        var user = new ApplicationUser()
        {
            Firstname = model.Firstname,
            Lastname = model.Lastname,
            Email = model.Email,
            UserName = model.Email,
            PhoneNumber = model.PhoneNumber,
        };

        //await _roleManager.CreateAsync(new IdentityRole(RoleConstants.Admin));
        //await _roleManager.CreateAsync(new IdentityRole(RoleConstants.DepartmentDirector));
        //await _roleManager.CreateAsync(new IdentityRole(RoleConstants.HRStaff));
        //await _roleManager.CreateAsync(new IdentityRole(RoleConstants.HRManager));
        //await _roleManager.CreateAsync(new IdentityRole(RoleConstants.SalesStaff));
        //await _roleManager.CreateAsync(new IdentityRole(RoleConstants.SalesManager));
        //await _roleManager.CreateAsync(new IdentityRole(RoleConstants.GeneralDirector));
        //var cc = await _roleManager.Roles.ToListAsync();

        // auto write to AspNetUser table
        var result = await _userManager.CreateAsync(user, model.Password);


        //var dbUser = await this._userManager.FindByNameAsync(model.Email);
        //await this._userManager.AddToRoleAsync(dbUser, RoleConstants.DepartmentDirector);
        //var bb = await this._userManager.AddToRoleAsync(dbUser, RoleConstants.GeneralDirector);


        return result;
    }
    #endregion

    #region [ Methods - Renew Token ]
    public async Task<RenewTokenResponseModel> RenewTokenAsync(RenewTokenModel model)
    {
        try
        {


            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(this._jwtSettingModels.Secret);
            var tokenValidParam = new TokenValidationParameters
            {
                // tự cấp token
                // can use third-party: authO
                ValidateIssuer = false,
                ValidateAudience = false,

                // ký vào token
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = false, // k kiểm tra token hết hạn 
            };

            // check 1: AccessToken is valid format
            var tokenInVerification = jwtTokenHandler.ValidateToken(model.AccessToken, tokenValidParam, out var validatedToken);

            // check 2: check algorithm
            if (validatedToken is JwtSecurityToken jwtSecurityToken)
            {
                var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase);
                if (!result)
                { // false
                    return new RenewTokenResponseModel
                    {
                        Success = false,
                        Message = "Invalid Token"
                    };
                }
            }

            // Check 3: check access token expire
            var utcExpireDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
            var expireDate = ConvertUnixTimeToDateTime(utcExpireDate);

            if (expireDate > DateTime.UtcNow)
            {
                return new RenewTokenResponseModel
                {
                    Success = false,
                    Message = "Access Token is not expired yet"
                };
            }

            // Check 4: Check refreshToken is existed in the db
            var dbToken = await this._refreshToken.GetSingleByRefreshTokenAsync(model.RefreshToken);
            if (dbToken == null)
            {
                return new RenewTokenResponseModel
                {
                    Success = false,
                    Message = "Refresh token is not exist"
                };
            }

            // Check 5: check refreshToken isUsed/isRevoke
            if (dbToken.IsUsed)
            {
                return new RenewTokenResponseModel
                {
                    Success = false,
                    Message = "Access Token is used"
                };
            }

            if (dbToken.IsRevoked)
            {
                return new RenewTokenResponseModel
                {
                    Success = false,
                    Message = "Access Token is revoked"
                };
            }

            // check 6: AccessTokenId == JwtId in refreshToken
            var jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            if (jti != dbToken.JwtId)
            {
                return new RenewTokenResponseModel
                {
                    Success = false,
                    Message = "Token Id is not match"
                };
            }

            // update token is used
            dbToken.IsRevoked = true;
            dbToken.IsUsed = true;
            await this._refreshToken.UpdateAsync(dbToken);

            // create a new token
            var dbUser = await this._userManager.Users.FirstOrDefaultAsync(x => x.Id == dbToken.UserId);
            var token = await this.GenerateTokenAsync(dbUser);

            return new RenewTokenResponseModel
            {
                Success = true,
                Message = "Renew token success",
                Data = token
            };

        } catch (Exception ex)
        {
            this._logger.LogWarning(ex.Message);
            return null;
        }
    }
    #endregion

    #region [ Methods - Private ]
    private string GenerateRefreshToken()
    {
        var result = string.Empty;
        var random = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(random);
        }

        result = Convert.ToBase64String(random);
        return result;
    }

    private async Task<TokenModel> GenerateTokenAsync(ApplicationUser user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var secretKeyBytes = Encoding.UTF8.GetBytes(this._jwtSettingModels.Secret);

        var roles = await this._userManager.GetRolesAsync(user);

        var rolesClaims = string.Empty;

        foreach (var item in roles.Select((value, i) => new { i, value }))
        {
            if (item.i == 0)
            {
                rolesClaims += item.value;
            } else
            {
                rolesClaims += ", " + item.value;
            }
        }
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, user.Fullname),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                //roles
                new Claim(ClaimTypes.Role, rolesClaims)
            }),
            Expires = DateTime.UtcNow.AddDays(3),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
        };
        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        var accessToken = jwtTokenHandler.WriteToken(token);
        var refreshToken = this.GenerateRefreshToken();

        var result = new TokenModel
        {
            Id = token.Id,
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };

        return result;

    }

    private async Task GenerateAndSaveRefreshTokenAsync(TokenModel tokenModel, string userId)
    {
        var refreshTokenEntity = new RefreshToken
        {
            Id = Guid.NewGuid().ToString(),
            JwtId = tokenModel.Id,
            Token = tokenModel.RefreshToken,
            UserId = userId,
            IsUsed = false,
            IsRevoked = false,
            IssuedAt = DateTime.UtcNow,
            ExpiredAt = DateTime.UtcNow.AddDays(30),
        };
        await this._refreshToken.AddAsync(refreshTokenEntity);
    }

    private DateTime ConvertUnixTimeToDateTime(long utcExpireDate)
    {
        var dateTimeInterval = new DateTime(year: 1970, month: 1, day: 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();
        return dateTimeInterval;
    }
    #endregion
}
