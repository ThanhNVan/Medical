using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
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
}
