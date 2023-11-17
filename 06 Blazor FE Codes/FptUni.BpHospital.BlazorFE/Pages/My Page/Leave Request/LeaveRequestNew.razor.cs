using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FptUni.BpHospital.HttpClientProviders;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using FptUni.BpHospital.Common;
using System.Linq;
using Microsoft.AspNetCore.Components.Authorization;

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

    #region [ Properties ]
    [CascadingParameter] public Task<AuthenticationState> AuthTask { get; set; }
    #endregion

    #region [ Properties - Data ]
    public LeaveRequest WorkItem { get; set; }

    public DateTime MinDate { get; set; } = DateTime.UtcNow;

    public DateTime MaxDate { get; set; } = DateTime.UtcNow.AddDays(365);

    public List<KeyIntValueStringModel> LeaveTypeOptions {  get; set; }

    public int SelectedLeaveType { get; set; }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync()
    {

        this.WorkItem = new LeaveRequest();
        this.WorkItem.StartDate = DateTime.UtcNow;
        this.WorkItem.EndDate = DateTime.UtcNow.AddDays(1);
        this.LeaveTypeOptions = Enum.GetValues(typeof(LeaveType)).Cast<LeaveType>()
           .Select(x => new KeyIntValueStringModel { Key = (int)x, Value = x.ToString() }).ToList();

    }
    #endregion

    #region [ Methods - Create ]
    public async Task CreateAsync()
    {
        var user = await this.AuthTask;
        var userEmail = user.User.Claims.FirstOrDefault(x => x.Type == "email").Value;
        var userId = await this.HttpClientContext.User.GetUserIdByEmailAsync(userEmail);
        var payload = new LeaveRequest();

        payload.StartDate = this.WorkItem.StartDate;
        payload.EndDate = this.WorkItem.EndDate;
        payload.TotalDay = this.GetBusinessDays(this.WorkItem.StartDate, this.WorkItem.EndDate);
        payload.LeaveType = (LeaveType)this.SelectedLeaveType;
        payload.LeaveState = LeaveState.Processing;
        payload.UserId = userId.Value;

        var result = await HttpClientContext.LeaveRequest.AddAsync(payload);
        var aa = 1;
        if (result)
        {
            await JSRuntime.InvokeVoidAsync("alert", "Added");
            return;
        } else
        {
            await JSRuntime.InvokeVoidAsync("alert", "Something is wrong, please try latter");
            return;
        }
    }
    #endregion

    #region [ Methods -  ]
    public int GetBusinessDays(DateTime startD, DateTime endD)
    {
        double calcBusinessDays =
            1 + ((endD - startD).TotalDays * 5 -
            (startD.DayOfWeek - endD.DayOfWeek) * 2) / 7;

        if (endD.DayOfWeek == DayOfWeek.Saturday) calcBusinessDays--;
        if (startD.DayOfWeek == DayOfWeek.Sunday) calcBusinessDays--;

        var isValid = int.TryParse(calcBusinessDays.ToString(), out var result);
        return result;
    }
    #endregion
}
