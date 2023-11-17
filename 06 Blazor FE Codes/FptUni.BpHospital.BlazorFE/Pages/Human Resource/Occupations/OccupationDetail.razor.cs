﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FptUni.BpHospital.HttpClientProviders;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Components;

namespace FptUni.BpHospital.BlazorFE;

public partial class OccupationDetail
{
    #region [ Properties - Parametter]
    [Parameter]
    public string Id { get; set; }
    #endregion

    #region [ Properties - Inject]
    [Inject]
    private NavigationManager NavigationManager { get; set; }

    [Inject]
    private HttpClientContext HttpClientContext { get; set; }
    #endregion

    #region [ Properties - Data ]
    public Occupation WorkItem { get; set; }

    public IList<User> Users { get; set; }

    public IList<Occupation> OccupationList { get; set; }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync()
    {
        this.WorkItem = new Occupation();
        this.Users = new List<User>();
        this.OccupationList = new List<Occupation>();

        await this.LoadDataAsync();
    }
    #endregion

    #region [ Methods - Data ]
    public async Task LoadDataAsync()
    {
        this.WorkItem = await HttpClientContext.Occupation.GetSingleByIdAsync(this.Id);
        this.Users = await HttpClientContext.User.GetListByOccupationIdAsync(this.Id);
        this.OccupationList = await HttpClientContext.Occupation.GetListAllAsync();
        foreach (var item in this.Users)
        {
            item.Occupation = this.OccupationList.FirstOrDefault(x => x.Id == item.OccupationId);
        }
    }
    #endregion

    #region [ Methods -  ]
    public void ViewUserDetail(string userId)
    {
        this.NavigationManager.NavigateTo($"/Hr/User/{userId}");
    }
    #endregion
}