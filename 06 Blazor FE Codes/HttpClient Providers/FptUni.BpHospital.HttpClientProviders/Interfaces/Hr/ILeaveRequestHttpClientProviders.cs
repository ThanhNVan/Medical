﻿using System.Collections.Generic;
using System.Threading.Tasks;
using FptUni.BpHospital.Common;
using FptUni.BpHostpital.HR.Utils;
using ShareLibrary.EntityProviders;

namespace FptUni.BpHospital.HttpClientProviders;

public interface ILeaveRequestHttpClientProviders : IBaseProvider<LeaveRequest>
{
    #region [ Methods - List ]
    Task<IList<LeaveRequest>> GetListByUserIdAsync(GetByUserIdFromAndEndDateModel model);

    Task<IList<LeaveRequest>> GetListProcessingStateAsync();

    Task<IList<LeaveRequest>> GetListByUserIdAsync(string userId);
    #endregion

    #region [ Methods - Update ]
    Task<bool> ApproveAsync(string leaveRequestId);
    Task<bool> DenyAsync(string leaveRequestId);
    #endregion
}
