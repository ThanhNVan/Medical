using FptUni.BpHostpital.HR.Repositories;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.Services;

namespace FptUni.BpHostpital.HR.Services;

public class AttendanceService : BaseServices<Attendance, IAttendanceRepository, HrDbContext>, IAttendanceService
{
    #region [ CTor ]
    public AttendanceService(ILogger<AttendanceService> logger, IAttendanceRepository repository, IEncriptionProvider encriptionProvider) : base(logger, repository, encriptionProvider)
{
}
    #endregion
}