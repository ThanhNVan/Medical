namespace FptUni.BpHostpital.HR.Services;

public class ServiceContext
{
    #region [ CTor ]
    public ServiceContext(IContactPersonService contactPerson,
                            IDepartmentService department,
                            IProfileService profile,
                            IRoleService role,
                            IUserRoleService userRole,
                            IUserService user,
                            IOccupationService occupation,
                            ILeaveRequestService leaveRequest,
                            IAttendanceService attendance)
    {
        ContactPerson = contactPerson;
        Department = department;
        Profile = profile;
        Role = role;
        UserRole = userRole;
        User = user;
        Occupation = occupation;
        LeaveRequest = leaveRequest;
        Attendance = attendance;
    }
    #endregion

    #region [ Properties ]
    public IContactPersonService ContactPerson { get; }
    public IDepartmentService Department { get; }
    public IProfileService Profile { get; }
    public IRoleService Role { get; }
    public IUserRoleService UserRole { get; }
    public IUserService User { get; }
    public IOccupationService Occupation { get; }
    public ILeaveRequestService LeaveRequest { get; }
    public IAttendanceService Attendance { get; }
    #endregion
}
