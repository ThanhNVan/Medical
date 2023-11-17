using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using FptUni.BpHospital.Common;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShareLibrary.EntityProviders;

namespace FptUni.BpHospital.HttpClientProviders;

public class UserHttpClientProviders : BaseHrHttpClientProviders<User>, IUserHttpClientProviders
{
    #region [ CTor ]
    public UserHttpClientProviders(ISessionStorageService _sessionStorage, IHttpClientFactory httpClientFactory, ILogger<UserHttpClientProviders> logger, IEncriptionProvider encriptionProvider) : base(_sessionStorage, httpClientFactory, logger, encriptionProvider)
    {
        this._entityUrl = EntityUrl.User;
    }
    #endregion

    #region [ Methods - List ]
    public async Task<IList<User>> GetListByOccupationIdAsync(string occupationId)
    {
        var result = default(List<User>);
        try
        {
            var httpClient = await base.GetHrClientAsync();
            var url = this._entityUrl + UrlConstant.GetListByOccupationId + occupationId;
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<List<User>>(await response.Content.ReadAsStringAsync());
            }

        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
        }
        return result;
    }
    #endregion
}
