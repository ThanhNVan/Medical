using Medical.Identity.DataProviders;
using Medical.Identity.EntityProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ShareLibrary.DataProviders;
using ShareLibrary.LogicProviders;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Identity.LogicProviders;

public class UserLogicProviders : BaseLogicProvider<User, IUserDataProviders, IdentityDbContext>, IUserLogicProviders
{
    #region [ Properties ]
    private readonly AppSettingModel _appSettingModel;
    private readonly IdentityDataContext _dataContext;
    #endregion

    #region [ CTor ]
    public UserLogicProviders(ILogger<BaseLogicProvider<User, IUserDataProviders, IdentityDbContext>> logger, IUserDataProviders dataProvider, IEncriptionProvider _encriptionProvider, AppSettingModel appSettingModel, IdentityDataContext dataContext) : base(logger, dataProvider, _encriptionProvider)
    {
        _appSettingModel = appSettingModel;
        this._dataContext = dataContext;
    }
    #endregion

    #region [ Methods - Override ]
    public async override Task<bool> AddAsync(User entity)
    {
        var passwordHash = this._encriptionProvider.HashWithSalt(entity.PasswordHash, entity.Id);
        //var paasswordHash = this._encriptionProvider.Encrypt(entity.PasswordHash, "");

        entity.PasswordHash = passwordHash;

        return await base.AddAsync(entity);
    }
    #endregion

    #region [ Methods - Sign In ]
    public async Task<SignInSuccessModel> GetSingleBySignInAsync(SignInModel model)
    {
        var result = default(SignInSuccessModel);
        if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
        {
            return result;
        }

        try
        {
            var dbResult = await this._dataProvider.GetSingleByEmailAsync(model.Email);
            if (dbResult == null)
            {
                return result;
            } 

            var hashPassword = this._encriptionProvider.HashWithSalt(model.Password, dbResult.Id);
            if (hashPassword != dbResult.PasswordHash)
            {
                return result;
            }

            result = new SignInSuccessModel();
            var roleString = await this._dataContext.UserRole.GetStringRoleByUserIdAsync(dbResult.Id);
            var token = await this.GenerateTokenAsync(dbResult, roleString);

            result.Email = dbResult.Email;
            result.Fullname = dbResult.Fullname;
            result.AccessToken = token.AccessToken;
            result.RefreshToken = token.RefreshToken;

            return result;
        } 
        catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return result;
        }
    }
    #endregion

    #region [ Methods - RenewToken ]
    public async Task<TokenModel> RenewTokenAsync(TokenModel model)
    {
        var final = default(TokenModel);
        try
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettingModel.SecretKey);
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
            if (validatedToken is JwtSecurityToken jwtSecurityToken) {
                var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase);
                if (!result) { // false
                    return null; //"Invalid Token"
                }
            }

            // Check 3: check access token expire
            var utcExpireDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
            var expireDate = ConvertUnixTimeToDateTime(utcExpireDate);

            if (expireDate > DateTime.UtcNow)
            {
                return null; //"Access Token is not expired yet"
            }

            // Check 4: Check refreshToken is existed in the db
            
            var dbToken = await this._dataContext.RefreshToken.GetSingleByTokenAsync(model.RefreshToken);
            if (dbToken == null)
            {
                return null; // "Refresh token is not exist"
            }

            // Check 5: check refreshToken isUsed/isRevoke
            if (dbToken.IsUsed)
            {
                return null; //"Access Token is used"
            }

            if (dbToken.IsRevoked)
            {
                return null; //"Access Token is revoked"
            }

            // check 6: AccessTokenId == JwtId in refreshToken
            var jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            if (jti != dbToken.JwtId)
            {
                return null; //"Token Id is not match"
            }

            // update token is used
            dbToken.IsRevoked = true;
            dbToken.IsUsed = true;
            await this._dataContext.RefreshToken.UpdateAsync(dbToken);

            var dbUser = await this._dataContext.User.GetSingleByIdAsync(dbToken.UserId);
            var roleString = await this._dataContext.UserRole.GetStringRoleByUserIdAsync(dbUser.Id);
            var token = await this.GenerateTokenAsync(dbUser, roleString);

            return token; //"Renew token success",
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return final;
        }
    }
    #endregion

    #region [ Private Methods -  ]
    private async  Task<TokenModel> GenerateTokenAsync(User user,string userRoleString)
    {
        var userRole = string.Empty;

        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettingModel.SecretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, user.Fullname),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                // roles
                new Claim(ClaimTypes.Role, userRoleString),
            }),
            Expires = DateTime.UtcNow.AddDays(3),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
        };
        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        var accessToken = jwtTokenHandler.WriteToken(token);
        var refreshToken = GenerateRefreshToken();

        var refreshTokenEntity = new RefreshToken
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = DateTime.UtcNow,
            LastUpdatedAt = DateTime.UtcNow,
            IsDeleted = false,
            JwtId = token.Id,
            Token = refreshToken,
            UserId = user.Id,
            IsUsed = false,
            IsRevoked = false,
            IssuedAt = DateTime.UtcNow,
            ExpiredAt = DateTime.UtcNow.AddDays(30),
        };

        await this._dataContext.RefreshToken.AddAsync(refreshTokenEntity);

        var result = new TokenModel
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };

        return result;
    }

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

    private DateTime ConvertUnixTimeToDateTime(long utcExpireDate)
    {
        var dateTimeInterval = new DateTime(year: 1970, month: 1, day: 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();
        return dateTimeInterval;
    }
    #endregion
}
