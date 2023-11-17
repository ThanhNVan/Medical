using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FptUni.BpHostpital.HR.Utils;
using ShareLibrary.Services;

namespace FptUni.BpHostpital.HR.Services;

public interface ILeaveRequestService : IBaseService<LeaveRequest>
{
    #region [ Methods - List ]
    Task<IList<LeaveRequest>> GetListByUserIdAsync(string userId, DateTime fromDate, DateTime endDate);

    Task<IList<LeaveRequest>> GetListProcessingStateAsync();
    #endregion

    #region [ Methods - Update ]
    Task<bool> ApproveAsync(string leaveRequestId);
    Task<bool> DenyAsync(string leaveRequestId);
    #endregion
}

