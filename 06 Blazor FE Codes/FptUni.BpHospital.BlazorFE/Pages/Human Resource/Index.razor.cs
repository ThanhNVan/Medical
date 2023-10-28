﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using FptUni.BpHospital.Common.DTOs;
using FptUni.BpHospital.HttpClientProviders;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Components;

namespace FptUni.BpHospital.BlazorFE.HR;

public partial class Index
{
    #region [ Properties - Inject]
    [Inject]
    private NavigationManager NavigationManager { get; set; }

    [Inject]
    private ISessionStorageService SessionStorage { get; set; }

    [Inject]
    private HttpClientContext HttpClientContext { get; set; }
    #endregion

    #region [ Properties ]
    private UserSession Session { get; set; }

    public IList<User> WorkItemList { get; set; }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync()
    {

        this.Session = await SessionStorage.GetItemAsync<UserSession>(nameof(UserSession));

        this.WorkItemList = await HttpClientContext.User.GetListAllAsync(Session.Email, Session.AccessToken);

    }
    #endregion
}
