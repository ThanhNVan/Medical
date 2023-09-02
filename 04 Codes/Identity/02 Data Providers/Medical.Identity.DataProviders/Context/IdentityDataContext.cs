﻿using ShareLibrary.DataProviders;

namespace Medical.Identity.DataProviders;

public class IdentityDataContext
{
    #region [ CTor ]
    public IdentityDataContext(IEncriptionProvider encription,
                                IRefreshTokenDataProviders refreshToken,
                                IRoleDataProviders role,
                                IUserDataProviders user,
                                IUserRoleDataProviders userRole,
                                IDepartmentDataProviders department)
    {
        Encription = encription;
        RefreshToken = refreshToken;
        Role = role;
        User = user;
        UserRole = userRole;
        Department = department;
    }

    #endregion

    #region [ Properties ]
    public IEncriptionProvider Encription { get; }
    public IRefreshTokenDataProviders RefreshToken { get; }
    public IRoleDataProviders Role { get; }
    public IUserDataProviders User { get; }
    public IUserRoleDataProviders UserRole { get; }
    public IDepartmentDataProviders Department { get; }

    #endregion
}
