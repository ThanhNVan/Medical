using System.Net.Http;
using Blazored.SessionStorage;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;

namespace FptUni.BpHospital.HttpClientProviders;

public class DepartmentHttpClientProviders : BaseHrHttpClientProviders<Department>, IDepartmentHttpClientProviders
{
    #region [ CTor ]
    public DepartmentHttpClientProviders(ISessionStorageService _sessionStorage, IHttpClientFactory httpClientFactory, ILogger<DepartmentHttpClientProviders> logger, IEncriptionProvider encriptionProvider) : base(_sessionStorage, httpClientFactory, logger, encriptionProvider)
    {
        this._entityUrl = EntityUrl.Department;
    }
    #endregion
}
