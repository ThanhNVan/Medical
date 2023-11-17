using System.Threading.Tasks;
using FptUni.BpHospital.Common;
using FptUni.BpHospital.HttpClientProviders;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace FptUni.BpHospital.BlazorFE;

public partial class LeaveRequestDetail
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
        this.WorkItem.User = await HttpClientContext.User.GetSingleByIdAsync(this.WorkItem.UserId);
        this.StateHasChanged();
    }
    #endregion

    #region [ Methods -  ]
    public async Task ApproveAsync()
    {

        var result = await HttpClientContext.LeaveRequest.ApproveAsync(this.WorkItem.Id);

        if (result)
        {
            this.NavigationManager.NavigateTo($"/Hr/LeaveRequest/");
            return;
        }else
        {

            await JSRuntime.InvokeVoidAsync("alert", "Something is wrong, please try latter");
            return;
        }
    }
    
    public async Task DenyAsync()
    {
        var result = await HttpClientContext.LeaveRequest.DenyAsync(this.WorkItem.Id);

        if (result)
        {
            this.NavigationManager.NavigateTo($"/Hr/LeaveRequest/");
            return;
        } else
        {
            await JSRuntime.InvokeVoidAsync("alert", "Something is wrong, please try latter");
            return;
        }

    }
    #endregion
}
