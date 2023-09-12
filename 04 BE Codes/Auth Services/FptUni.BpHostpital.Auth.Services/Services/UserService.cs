using FptUni.BpHostpital.Auth.Repositories;
using FptUni.BpHostpital.Auth.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
    private readonly IRefreshTokenRepository _refreshToken;
    private readonly JwtSettingModels _jwtSettingModels;
    #endregion

    #region [ CTor ]
    public UserService(UserManager<ApplicationUser> userManager,
                        SignInManager<ApplicationUser> signInManager,
                        IRefreshTokenRepository refreshToken,
                        JwtSettingModels jwtSettingModels)
    {
        this._userManager = userManager;
        this._signInManager = signInManager;
        this._refreshToken = refreshToken;
        this._jwtSettingModels = jwtSettingModels;
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
            UserName = model.Email
        };

        // auto write to AspNetUser table
        return await _userManager.CreateAsync(user, model.Password);
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
            rolesClaims += item.value;
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
    #endregion
}
