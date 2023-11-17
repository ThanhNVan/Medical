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

public class LeaveRequestHttpClientProviders : BaseHrHttpClientProviders<LeaveRequest>, ILeaveRequestHttpClientProviders
{
    #region [ CTor ]
    public LeaveRequestHttpClientProviders(ISessionStorageService _sessionStorage, IHttpClientFactory httpClientFactory, ILogger<LeaveRequestHttpClientProviders> logger, IEncriptionProvider encriptionProvider) : base(_sessionStorage, httpClientFactory, logger, encriptionProvider)
    {
        this._entityUrl = EntityUrl.LeaveRequest;
    }
    #endregion

    #region [ Methods - List ]
    public async Task<IList<LeaveRequest>> GetListByUserIdAsync(GetByUserIdFromAndEndDateModel model)
    {
        var result = default(List<LeaveRequest>);
        try
        {
            var httpClient = await base.GetHrClientAsync();
            var url = this._entityUrl + UrlConstant.GetListByUserId;
            var response = await httpClient.PostAsJsonAsync(url, model);
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<List<LeaveRequest>>(await response.Content.ReadAsStringAsync());
            }

        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
        }
        return result;
    }

    public async Task<IList<LeaveRequest>> GetListProcessingStateAsync()
    {
        var result = default(List<LeaveRequest>);
        try
        {
            var httpClient = await base.GetHrClientAsync();
            var url = this._entityUrl + UrlConstant.GetListProcessingState;
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<List<LeaveRequest>>(await response.Content.ReadAsStringAsync());
            }

        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
        }
        return result;
    }
    #endregion

    #region [ Methods - Update ]
    public async Task<bool> ApproveAsync(string leaveRequestId)
    {
        var result = default(bool);
        try
        {
            var httpClient = await base.GetHrClientAsync();
            var url = this._entityUrl + UrlConstant.Approve;
            var response = await httpClient.PutAsJsonAsync(url, leaveRequestId);
            if (response.IsSuccessStatusCode)
            {
                result = true;
            }

        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
        }
        return result;
    }

    public async Task<bool> DenyAsync(string leaveRequestId)
    {
        var result = default(bool);
        try
        {
            var httpClient = await base.GetHrClientAsync();
            var url = this._entityUrl + UrlConstant.Deny;
            var response = await httpClient.PutAsJsonAsync(url, leaveRequestId);
            if (response.IsSuccessStatusCode)
            {
                result = true;
            }

        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
        }
        return result;
    }
    #endregion
}
