﻿using System.Net.Http;
using Blazored.SessionStorage;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;

namespace FptUni.BpHospital.HttpClientProviders;

public class UserRoleHttpClientProviders : BaseHrHttpClientProviders<UserRole>, IUserRoleHttpClientProviders
{
    #region [ CTor ]
    public UserRoleHttpClientProviders(ISessionStorageService _sessionStorage, IHttpClientFactory httpClientFactory, ILogger<UserRoleHttpClientProviders> logger, IEncriptionProvider encriptionProvider) : base(_sessionStorage, httpClientFactory, logger, encriptionProvider)
    {
        this._entityUrl = EntityUrl.UserRole;
    }
    #endregion
}