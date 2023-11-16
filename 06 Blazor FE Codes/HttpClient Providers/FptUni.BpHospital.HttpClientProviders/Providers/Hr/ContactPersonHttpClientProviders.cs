using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using FptUni.BpHospital.Common;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShareLibrary.EntityProviders;

namespace FptUni.BpHospital.HttpClientProviders;

public class ContactPersonHttpClientProviders : BaseHrHttpClientProviders<ContactPerson>, IContactPersonHttpClientProviders
{
    #region [ CTor ]
    public ContactPersonHttpClientProviders(ISessionStorageService _sessionStorage, IHttpClientFactory httpClientFactory, ILogger<ContactPersonHttpClientProviders> logger, IEncriptionProvider encriptionProvider) : base(_sessionStorage, httpClientFactory, logger, encriptionProvider)
    {
        this._entityUrl = EntityUrl.ContactPerson;
    }
    #endregion

    #region [ Methods - List ]
    public async Task<IList<ContactPerson>> GetListByUserIdAsync(string userId)
    {
        var result = default(List<ContactPerson>);
        try
        {
            var httpClient = await base.GetHrClientAsync();
            var url = this._entityUrl + UrlConstant.GetListByUserId + userId;
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<List<ContactPerson>>(await response.Content.ReadAsStringAsync());
            }

        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
        }
        return result;
    }
    #endregion
}
