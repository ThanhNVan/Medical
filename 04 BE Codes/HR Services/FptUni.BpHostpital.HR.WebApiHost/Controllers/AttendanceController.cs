using FptUni.BpHostpital.HR.Services;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.WebApiProviders;

namespace FptUni.BpHostpital.HR.WebApiHost;

[Authorize(Policy = nameof(RoleConstants.HRManager))]
public class AttendanceController : BaseWebApiController<Attendance, IAttendanceService, HrDbContext>
{
    #region [ CTor ]
    public AttendanceController(ILogger<AttendanceController> logger, IAttendanceService logicProvider) : base(logger, logicProvider)
    {
    }
    #endregion
}
