using FptUni.BpHospital.Common.DTOs;
using System.Threading.Tasks;

namespace FptUni.BpHospital.HttpClientProviders;

public interface IAuthenticationHttpClientProviders
{
    #region [ Methods -  ]
    Task<UserSession> SignInAsync(SignInModel model);

    Task<TokenModel> RenowTokenAsync(string emailKey, TokenModel model, string accessToken);
    #endregion
}
