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
                            IOccupationService occupation)
    {
        ContactPerson = contactPerson;
        Department = department;
        Profile = profile;
        Role = role;
        UserRole = userRole;
        User = user;
        Occupation = occupation;
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
    #endregion
}
