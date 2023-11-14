using FptUni.BpHostpital.HR.Services;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using ShareLibrary.WebApiProviders;

namespace FptUni.BpHostpital.HR.WebApiHost;

public class LeaveRequestController : BaseWebApiController<LeaveRequest, ILeaveRequestService, HrDbContext>
{
    #region [ CTor ]
    public LeaveRequestController(ILogger<LeaveRequestController> logger, ILeaveRequestService logicProvider) : base(logger, logicProvider)
    {
    }
    #endregion
}
