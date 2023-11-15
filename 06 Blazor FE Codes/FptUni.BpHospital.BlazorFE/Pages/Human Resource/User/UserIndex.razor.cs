using System.Collections.Generic;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using FptUni.BpHospital.Common.DTOs;
using FptUni.BpHospital.HttpClientProviders;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Components;

namespace FptUni.BpHospital.BlazorFE;

public partial class UserIndex
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
    public IList<User> WorkItemList { get; set; }

    public IList<Occupation> OccupationList { get; set; }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync()
    {

        this.WorkItemList = new List<User>();
        this.OccupationList = new List<Occupation>();
        await this.LoadDataAsync();
    }
    #endregion

    #region [ Methods - LoadData ]
    public async Task LoadDataAsync()
    {
        this.WorkItemList = await HttpClientContext.User.GetListIsNotDeletedAsync();
        this.StateHasChanged();
    }
    #endregion

    #region [ Methods -  ]
    public void ViewDetail(string userId)
    {
        this.NavigationManager.NavigateTo($"/Hr/User/{userId}");
    }
    
    public void Onboard()
    {
        this.NavigationManager.NavigateTo($"/Hr/User/");
    }
    #endregion
}
