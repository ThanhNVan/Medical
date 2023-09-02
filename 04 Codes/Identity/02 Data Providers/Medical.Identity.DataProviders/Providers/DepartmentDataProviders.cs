using Medical.Identity.EntityProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.DataProviders;

namespace Medical.Identity.DataProviders;

public class DepartmentDataProviders : BaseDataProvider<Department, IdentityDbContext>, IDepartmentDataProviders
{
    #region [ CTor ]
    public DepartmentDataProviders(ILogger<BaseDataProvider<Department, IdentityDbContext>> logger, IDbContextFactory<IdentityDbContext> dbContextFactory, IEncriptionProvider encriptionProvider) : base(logger, dbContextFactory, encriptionProvider)
    {
    }
    #endregion
}
