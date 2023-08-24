using Medical.Identity.EntityProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.DataProviders;

namespace Medical.Identity.DataProviders;

public class UserRoleDataProviders : BaseDataProvider<UserRole, IdentityDbContext>, IUserRoleDataProviders
{
    #region [ CTor ]
    public UserRoleDataProviders(ILogger<BaseDataProvider<UserRole, IdentityDbContext>> logger, IDbContextFactory<IdentityDbContext> dbContextFactory, IEncriptionProvider encriptionProvider) : base(logger, dbContextFactory, encriptionProvider)
    {
    }
    #endregion
}
