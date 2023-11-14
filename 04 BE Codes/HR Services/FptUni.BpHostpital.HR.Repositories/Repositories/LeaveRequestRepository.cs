using FptUni.BpHostpital.HR.Repositories;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.Repositories;

namespace FptUni.BpHostpital.HR;

public class LeaveRequestRepository : BaseRepository<LeaveRequest, HrDbContext>, ILeaveRequestRepository
{
    #region [ CTor ]
    public LeaveRequestRepository(ILogger<LeaveRequestRepository> logger, IDbContextFactory<HrDbContext> dbContextFactory, IEncriptionProvider encriptionProvider) : base(logger, dbContextFactory, encriptionProvider)
    {
    }
    #endregion
}
