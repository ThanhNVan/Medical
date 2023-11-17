using Blazored.SessionStorage;
using FptUni.BpHospital.Common.DTOs;
using FptUni.BpHospital.HttpClientProviders;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FptUni.BpHospital.BlazorFE;

public partial class OccupationIndex
{
    #region [ Properties - Inject]
    [Inject]
    private NavigationManager NavigationManager { get; set; }

    [Inject]
    private HttpClientContext HttpClientContext { get; set; }
    #endregion

    #region [ Properties ]
    public IList<Occupation> WorkItemList { get; set; }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync()
    {
        this.WorkItemList =new List<Occupation>();
        await this.LoadDataAsync();
    }
    #endregion

    #region [ Methods - LoadData ]
    public async Task LoadDataAsync()
    {
        this.WorkItemList = await HttpClientContext.Occupation.GetListIsNotDeletedAsync();
        this.StateHasChanged();
    }
    #endregion

    #region [ Methods -  ]
    public void NewOccupation()
    {
        this.NavigationManager.NavigateTo($"/Hr/Occupation/New");
    }

    public void ViewDetail(string occupationId)
    {
        this.NavigationManager.NavigateTo($"/Hr/Occupation/{occupationId}");
    }
    #endregion
}
