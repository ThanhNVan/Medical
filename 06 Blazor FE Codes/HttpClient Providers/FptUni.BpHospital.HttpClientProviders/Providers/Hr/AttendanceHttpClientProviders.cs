using System.Net.Http;
using Blazored.SessionStorage;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;

namespace FptUni.BpHospital.HttpClientProviders;

public class AttendanceHttpClientProviders : BaseHrHttpClientProviders<Attendance>, IAttendanceHttpClientProviders
{
    #region [ CTor ]
    public AttendanceHttpClientProviders(ISessionStorageService _sessionStorage, IHttpClientFactory httpClientFactory, ILogger<AttendanceHttpClientProviders> logger, IEncriptionProvider encriptionProvider) : base(_sessionStorage, httpClientFactory, logger, encriptionProvider)
    {
        this._entityUrl = EntityUrl.Attendance;
    }
    #endregion
}
    