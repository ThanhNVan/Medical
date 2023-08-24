namespace Medical.Identity.LogicProviders;

public class IdentityLogicContext
{
    #region [ CTor ]
    public IdentityLogicContext(IRefreshTokenLogicProviders refreshToken,
                                IRoleLogicProviders role,
                                IUserLogicProviders user,
                                IUserRoleLogicProviders userRole)
    {
        RefreshToken = refreshToken;
        Role = role;
        User = user;
        UserRole = userRole;
    }
    #endregion

    #region [ Properties ]
    public IRefreshTokenLogicProviders RefreshToken { get; }
    public IRoleLogicProviders Role { get; }
    public IUserLogicProviders User { get; }
    public IUserRoleLogicProviders UserRole { get; }
    #endregion
}
