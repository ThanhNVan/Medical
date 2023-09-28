using FptUni.BpHospital.Common.DTOs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShareLibrary.EntityProviders;
using ShareLibrary.HttpClientProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FptUni.BpHospital.HttpClientProviders;

public class AuthenticationHttpClientProviders : IAuthenticationHttpClientProviders
{
    #region [ Fields ]
    protected readonly IHttpClientFactory _httpClientFactory;
    protected readonly ILogger<AuthenticationHttpClientProviders> _logger;
    protected readonly IEncriptionProvider _encriptionProvider;
    protected string _entityUrl;
    #endregion

    #region [ CTor ]
    public AuthenticationHttpClientProviders(IHttpClientFactory httpClientFactory,
                                            ILogger<AuthenticationHttpClientProviders> logger,
                                            IEncriptionProvider encriptionProvider)
	{
        this._httpClientFactory = httpClientFactory;
        this._logger = logger;
        this._encriptionProvider = encriptionProvider;
        this._entityUrl = EntityUrl.Authentication;

    }
    #endregion

    #region [ Methods -  ]
    public async Task<UserSession> SignInAsync(SignInModel model)
	{
        try
        {
            var url = this._entityUrl + BaseMethodUrl.SignIn;

            var httpClient = this.CreateClient();

            var response = await httpClient.PostAsJsonAsync(url, model);

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<UserSession>(await response.Content.ReadAsStringAsync());
                return result;
            }

            return null;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return null;
        }
    }

    public async Task<TokenModel> RenowTokenAsync(string emailKey, TokenModel model, string accessToken)
	{
        try
        {
            var url = this._entityUrl + BaseMethodUrl.RenewToken;

            var httpClient = this.CreateClient(emailKey: emailKey,accessToken: accessToken);

            var response = await httpClient.PostAsJsonAsync(url, model);

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<TokenModel>(await response.Content.ReadAsStringAsync());
                return result;
            }

            return null;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return null;
        }
    }
    #endregion

    #region [ Private Methods -  ]
    protected HttpClient CreateClient(string emailKey= "", string clientName = "AuthClient", string accessToken = "")
    {
        // RoutingUrl.BaseClientName = "BaseClientName"
        var result = this._httpClientFactory.CreateClient(clientName);

        if (!string.IsNullOrEmpty(accessToken))
        {
            var decryptedAccessToken = this._encriptionProvider.DecryptWithSalt(accessToken, emailKey);
            result.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", decryptedAccessToken);
        }

        return result;
    }
    #endregion
}
