using Medical.Identity.EntityProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.DataProviders;

namespace Medical.Identity.DataProviders;

public class RoleDataProviders : BaseDataProvider<Role, IdentityDbContext>, IRoleDataProviders
{
    #region [ CTor ]
    public RoleDataProviders(ILogger<BaseDataProvider<Role, IdentityDbContext>> logger, IDbContextFactory<IdentityDbContext> dbContextFactory, IEncriptionProvider encriptionProvider) : base(logger, dbContextFactory, encriptionProvider)
    {
    }
    #endregion
}
