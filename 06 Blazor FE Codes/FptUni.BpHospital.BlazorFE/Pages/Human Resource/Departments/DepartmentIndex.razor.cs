using Blazored.SessionStorage;
using FptUni.BpHospital.Common.DTOs;
using FptUni.BpHospital.HttpClientProviders;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FptUni.BpHospital.BlazorFE;

public partial class DepartmentIndex
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

    public IList<Department> WorkItemList { get; set; }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync()
    {

        this.WorkItemList = new List<Department>();
        await this.LoadDataAsync();
    }
    #endregion

    #region [ Methods - LoadData ]
    public async Task LoadDataAsync()
    {
        this.WorkItemList = await HttpClientContext.Department.GetListIsNotDeletedAsync();
        this.StateHasChanged();
    }
    #endregion
}
