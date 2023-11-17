using FptUni.BpHospital.HttpClientProviders;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FptUni.BpHospital.BlazorFE;

public partial class MyLeaveRequestDetail
{
    #region [ Properties - Parametter]
    [Parameter]
    public string Id { get; set; }
    #endregion

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
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync()
    {

        this.WorkItem = new LeaveRequest();
        await this.LoadDataAsync();

    }
    #endregion

    #region [ Methods - Data ]
    public async Task LoadDataAsync()
    {
        this.WorkItem = await HttpClientContext.LeaveRequest.GetSingleByIdAsync(this.Id);
        this.StateHasChanged();
    }
    #endregion
}
