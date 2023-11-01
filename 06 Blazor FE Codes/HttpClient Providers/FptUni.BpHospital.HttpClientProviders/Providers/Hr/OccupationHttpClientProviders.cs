using Blazored.SessionStorage;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using System.Net.Http;

namespace FptUni.BpHospital.HttpClientProviders;

public class OccupationHttpClientProviders : BaseHrHttpClientProviders<Occupation>, IOccupationHttpClientProviders
{
    #region [ CTor ]
    public OccupationHttpClientProviders(ISessionStorageService _sessionStorage, IHttpClientFactory httpClientFactory, ILogger<OccupationHttpClientProviders> logger, IEncriptionProvider encriptionProvider) : base(_sessionStorage, httpClientFactory, logger, encriptionProvider)
    {
        this._entityUrl = EntityUrl.Occupation;
    }
    #endregion
}
