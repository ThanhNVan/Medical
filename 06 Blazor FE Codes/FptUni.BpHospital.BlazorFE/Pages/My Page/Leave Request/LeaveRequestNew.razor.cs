using System;
using System.Threading.Tasks;
using FptUni.BpHospital.HttpClientProviders;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace FptUni.BpHospital.BlazorFE;

public partial class LeaveRequestNew
{
    #region [ Properties - Inject ]
    [Inject]
    private NavigationManager NavigationManager { get; set; }

    [Inject]
    private HttpClientContext HttpClientContext { get; set; }

    [Inject]
    private IJSRuntime JSRuntime { get; set; }
    #endregion

    #region [ Properties - Data ]
    public LeaveRequest WorkItem { get; set; }
    public DateTime MinDate { get; set; } = DateTime.UtcNow;
    public DateTime MaxDate { get; set; } = DateTime.UtcNow.AddDays(365);
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync()
    {

        this.WorkItem = new LeaveRequest();
        this.WorkItem.StartDate = DateTime.UtcNow;
        this.WorkItem.EndDate = DateTime.UtcNow.AddDays(1);
    }
    #endregion

    #region [ Methods - Create ]
    public async Task CreateAsync()
    {

    }
    #endregion
}
