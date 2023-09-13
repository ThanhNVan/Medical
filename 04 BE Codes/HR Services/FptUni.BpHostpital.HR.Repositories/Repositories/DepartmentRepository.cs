using FptUni.BpHostpital.HR.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.Repositories;

namespace FptUni.BpHostpital.HR.Repositories;

public class DepartmentRepository : BaseRepository<Department, HrDbContext>, IDepartmentRepository
{
    #region [ CTor ]
    public DepartmentRepository(ILogger<BaseRepository<Department, HrDbContext>> logger, IDbContextFactory<HrDbContext> dbContextFactory, IEncriptionProvider encriptionProvider) : base(logger, dbContextFactory, encriptionProvider)
    {
    }
    #endregion
}
