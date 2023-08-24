using Medical.Identity.DataProviders;
using Medical.Identity.EntityProviders;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ShareLibrary.DataProviders;
using ShareLibrary.LogicProviders;
using System;
using System.IdentityModel.Tokens.Jwt;
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
            var token = this.GenerateToken(dbResult, roleString);

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

    #region [ Private Methods -  ]
    private TokenModel GenerateToken(User user,string userRoleString)
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

        var result = new TokenModel
        {
            Id = token.Id,
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
    #endregion
}
