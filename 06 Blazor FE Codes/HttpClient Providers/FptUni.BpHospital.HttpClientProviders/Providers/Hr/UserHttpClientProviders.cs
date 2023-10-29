﻿using System.Net.Http;
using Blazored.SessionStorage;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
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
}
