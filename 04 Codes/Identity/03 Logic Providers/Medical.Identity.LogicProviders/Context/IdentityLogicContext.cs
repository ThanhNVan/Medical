namespace Medical.Identity.LogicProviders;

public class IdentityLogicContext
{
    #region [ CTor ]
    public IdentityLogicContext(IRefreshTokenLogicProviders refreshToken,
                                IRoleLogicProviders role,
                                IUserLogicProviders user,
                                IUserRoleLogicProviders userRole,
                                IDepartmentLogicProviders department)
    {
        RefreshToken = refreshToken;
        Role = role;
        User = user;
        UserRole = userRole;
        Department = department;
    }
    #endregion

    #region [ Properties ]
    public IRefreshTokenLogicProviders RefreshToken { get; }
    public IRoleLogicProviders Role { get; }
    public IUserLogicProviders User { get; }
    public IUserRoleLogicProviders UserRole { get; }
    public IDepartmentLogicProviders Department { get; }
    #endregion
}
