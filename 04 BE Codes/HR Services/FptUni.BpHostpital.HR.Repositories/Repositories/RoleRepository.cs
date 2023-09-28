using FptUni.BpHostpital.HR.Repositories;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.Repositories;
using ShareLibrary.EntityProviders;

namespace FptUni.BpHostpital.HR.Repositories;

public class RoleRepository : BaseRepository<Role, HrDbContext>, IRoleRepository
{
    #region [ CTor ]
    public RoleRepository(ILogger<RoleRepository> logger, IDbContextFactory<HrDbContext> dbContextFactory, IEncriptionProvider encriptionProvider) : base(logger, dbContextFactory, encriptionProvider)
    {
    }
    #endregion
}
