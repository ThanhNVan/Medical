using System.Net.Http;
using Blazored.SessionStorage;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
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
}
