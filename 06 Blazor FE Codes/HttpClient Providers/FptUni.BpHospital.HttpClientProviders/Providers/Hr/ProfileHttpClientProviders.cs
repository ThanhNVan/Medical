using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using FptUni.BpHospital.Common;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShareLibrary.EntityProviders;

namespace FptUni.BpHospital.HttpClientProviders;

public class ProfileHttpClientProviders : BaseHrHttpClientProviders<Profile>, IProfileHttpClientProviders
{
    #region [ CTor ]
    public ProfileHttpClientProviders(ISessionStorageService _sessionStorage, IHttpClientFactory httpClientFactory, ILogger<ProfileHttpClientProviders> logger, IEncriptionProvider encriptionProvider) : base(_sessionStorage, httpClientFactory, logger, encriptionProvider)
    {
        this._entityUrl = EntityUrl.Profile;
    }
    #endregion

    #region [ Single ]
    public async Task<Profile> GetSingleByUserIdAsync(string userId)
    {
        var result =  default(Profile);
        try
        {
            var httpClient = await base.GetHrClientAsync();
            var url = this._entityUrl + UrlConstant.GetSingleByUserId + userId;
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<Profile>(await response.Content.ReadAsStringAsync());
            }

        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
        }
        return result;
    }
    #endregion
}
