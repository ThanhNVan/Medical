using Microsoft.AspNetCore.Components;

namespace FptUni.BpHospital.BlazorFE;

public partial class HrIndex
{
    #region [ Properties - Inject ]
    [Inject]
    private NavigationManager NavigationManager { get; set; }
    #endregion

    #region [ Properties - Navigation ]
    public void ViewEmployee()
    {
        this.NavigationManager.NavigateTo($"/Hr/User/");
    }
    
    public void ViewReport()
    {
        this.NavigationManager.NavigateTo($"/Hr/Report/");
    }
          
    public void ViewLeaveRequest()
    {
        this.NavigationManager.NavigateTo($"/Hr/LeaveRequest/");
    }
    
    public void ViewAttendance()
    {
        this.NavigationManager.NavigateTo($"/Hr/Attendance/");
    }
    
    public void ViewDepartments()
    {
        this.NavigationManager.NavigateTo($"/Hr/Department/");
    }

    public void ViewOccupations()
    {
        this.NavigationManager.NavigateTo($"/Hr/Occupation/");
    }

    //public void ViewGeneralReport()
    //{
    //    this.NavigationManager.NavigateTo($"/Hr/Report/General");
    //}

    //public void ViewOvertimeReport()
    //{
    //    this.NavigationManager.NavigateTo($"/Hr/Report/Overtime");
    //}

    //public void ViewInternalReport()
    //{
    //    this.NavigationManager.NavigateTo($"/Hr/Report/Internal");
    //}
    #endregion
}
