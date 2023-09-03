using Medical.Identity.EntityProviders;
using ShareLibrary.DataProviders;

namespace Medical.Identity.DataProviders;

public interface IUserRoleDataProviders : IBaseDataProvider<UserRole, IdentityDbContext>
{
    #region [ Methods -  ]
    Task<string> GetStringDepartmentAndRoleByUserIdAsync(string userId);
    #endregion
}
