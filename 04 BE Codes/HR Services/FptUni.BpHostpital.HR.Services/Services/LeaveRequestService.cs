using FptUni.BpHostpital.HR.Repositories;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.Services;

namespace FptUni.BpHostpital.HR.Services;

public class LeaveRequestService : BaseServices<LeaveRequest, ILeaveRequestRepository, HrDbContext>, ILeaveRequestService
{
    #region [ CTor ]
    public LeaveRequestService(ILogger<LeaveRequestService> logger, ILeaveRequestRepository repository, IEncriptionProvider encriptionProvider) : base(logger, repository, encriptionProvider)
    {
    }
    #endregion
}
