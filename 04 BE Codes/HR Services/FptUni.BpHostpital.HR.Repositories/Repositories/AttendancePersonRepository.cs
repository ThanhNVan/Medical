using FptUni.BpHostpital.HR.Repositories;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.Repositories;

namespace FptUni.BpHostpital.HR;

public class AttendanceRepository : BaseRepository<Attendance, HrDbContext>, IAttendanceRepository
{
    #region [ CTor ]
    public AttendanceRepository(ILogger<AttendanceRepository> logger, IDbContextFactory<HrDbContext> dbContextFactory, IEncriptionProvider encriptionProvider) : base(logger, dbContextFactory, encriptionProvider)
    {
    }
    #endregion
}