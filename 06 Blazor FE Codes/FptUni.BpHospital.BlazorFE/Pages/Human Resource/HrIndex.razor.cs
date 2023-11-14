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
        this.NavigationManager.NavigateTo($"/Hr/User/Index");
    }
    
    public void ViewReport()
    {
        this.NavigationManager.NavigateTo($"/Hr/Report/Index");
    }
    
    public void ViewInternalReport()
    {
        this.NavigationManager.NavigateTo($"/Hr/Report/Internal");
    }
       
    public void ViewLeaveRequest()
    {
        this.NavigationManager.NavigateTo($"/Hr/LeaveRequest/Index");
    }
    
    public void ViewAttendance()
    {
        this.NavigationManager.NavigateTo($"/Hr/Attendance/Index");
    }
    
    public void ViewDepartments()
    {
        this.NavigationManager.NavigateTo($"/Hr/Department/Index");
    }

    public void ViewOccupations()
    {
        this.NavigationManager.NavigateTo($"/Hr/Occupation/Index");
    }

    //public void ViewGeneralReport()
    //{
    //    this.NavigationManager.NavigateTo($"/Hr/Report/General");
    //}

    //public void ViewOvertimeReport()
    //{
    //    this.NavigationManager.NavigateTo($"/Hr/Report/Overtime");
    //}
    #endregion
}
