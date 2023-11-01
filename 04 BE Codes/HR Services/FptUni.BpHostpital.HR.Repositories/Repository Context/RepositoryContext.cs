namespace FptUni.BpHostpital.HR.Repositories;

public class RepositoryContext
{
    #region [ CTor ]
    public RepositoryContext(IContactPersonRepository contactPerson,
                            IDepartmentRepository department,
                            IProfileRepository profile,
                            IRoleRepository role,
                            IUserRepository user,
                            IUserRoleRepository userRole,
                            IOccupationRepository occupation)
    {
        ContactPerson = contactPerson;
        Department = department;
        Profile = profile;
        Role = role;
        User = user;
        UserRole = userRole;
        Occupation = occupation;
    }

    #endregion

    #region [ Properties ]
    public IContactPersonRepository ContactPerson { get; }
    public IDepartmentRepository Department { get; }
    public IProfileRepository Profile { get; }
    public IRoleRepository Role { get; }
    public IUserRepository User { get; }
    public IUserRoleRepository UserRole { get; }
    public IOccupationRepository Occupation { get; }
    #endregion
}
