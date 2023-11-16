using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using FptUni.BpHospital.Common;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace FptUni.BpHospital.HttpClientProviders;

public class AttendanceHttpClientProviders : BaseHrHttpClientProviders<Attendance>, IAttendanceHttpClientProviders
{
    #region [ CTor ]
    public AttendanceHttpClientProviders(ISessionStorageService _sessionStorage, IHttpClientFactory httpClientFactory, ILogger<AttendanceHttpClientProviders> logger, IEncriptionProvider encriptionProvider) : base(_sessionStorage, httpClientFactory, logger, encriptionProvider)
    {
        this._entityUrl = EntityUrl.Attendance;
    }
    #endregion

    #region [ Methods - List ]
    public async Task<IList<Attendance>> GetListByUserIdAsync(GetByUserIdFromAndEndDateModel model)
    {
        var result = default(List<Attendance>);
        try
        {
            var httpClient = await base.GetHrClientAsync();
            var url = this._entityUrl + UrlConstant.GetListByUserId;
            var response = await httpClient.PostAsJsonAsync(url, model);
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<List<Attendance>>(await response.Content.ReadAsStringAsync());
            }

        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
        }
        return result;
    }
    #endregion
}
