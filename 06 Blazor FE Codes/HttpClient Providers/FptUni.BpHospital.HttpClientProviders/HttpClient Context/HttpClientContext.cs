namespace FptUni.BpHospital.HttpClientProviders;

public class HttpClientContext
{

	#region [ CTor ]
	public HttpClientContext(IAuthenticationHttpClientProviders authentication,
                            IContactPersonHttpClientProviders contactPerson,
                            IDepartmentHttpClientProviders department,
                            IOccupationHttpClientProviders occupation,
                            IProfileHttpClientProviders profile,
                            IRoleHttpClientProviders role,
							IUserHttpClientProviders user,
                            IUserRoleHttpClientProviders userRole)
	{
        Authentication = authentication;
        ContactPerson = contactPerson;
        Department = department;
        Occupation = occupation;
        Profile = profile;
        Role = role;
        User = user;
        UserRole = userRole;
    }

    #endregion

	#region [ Properties ]
    public IAuthenticationHttpClientProviders Authentication { get; }
    public IContactPersonHttpClientProviders ContactPerson { get; }
    public IDepartmentHttpClientProviders Department { get; }
    public IOccupationHttpClientProviders Occupation { get; }
    public IProfileHttpClientProviders Profile { get; }
    public IRoleHttpClientProviders Role { get; }
    public IUserHttpClientProviders User { get; }
    public IUserRoleHttpClientProviders UserRole { get; }
    #endregion
}
