using Blazored.SessionStorage;
using FptUni.BpHospital.HttpClientProviders;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FptUni.BpHospital.BlazorFE;

public partial class MyLeaveRequestIndex
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
    [CascadingParameter] public Task<AuthenticationState> AuthTask { get; set; }
    #endregion

    #region [ Properties ]
    public IList<LeaveRequest> WorkItemList { get; set; }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync()
    {

        this.WorkItemList = new List<LeaveRequest>();
        await this.LoadDataAsync();
    }
    #endregion

    #region [ Methods - LoadData ]
    public async Task LoadDataAsync()
    {
        var user = await this.AuthTask;
        var userEmail = user.User.Claims.FirstOrDefault(x => x.Type == "email").Value;
        var userId = (await this.HttpClientContext.User.GetUserIdByEmailAsync(userEmail)).Value;

        this.WorkItemList = await HttpClientContext.LeaveRequest.GetListByUserIdAsync(userId);

        if (this.WorkItemList is null || this.WorkItemList.Count == 0)
        {
            return;
        }
        this.StateHasChanged();
    }
    #endregion

    #region [ Methods -  ]
    public void ViewDetail(string leaveRequestId)
    {
        this.NavigationManager.NavigateTo($"/Hr/LeaveRequest/{leaveRequestId}");
    }

    public void NewLeaveRequest()
    {
        this.NavigationManager.NavigateTo($"/MyPage/LeaveRequest/New");
    }
    #endregion
}
