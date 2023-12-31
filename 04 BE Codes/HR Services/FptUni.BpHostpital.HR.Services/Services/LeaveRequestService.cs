﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System;
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

    #region [ Methods - List ]
    public async Task<IList<LeaveRequest>> GetListByUserIdAsync(string userId, DateTime fromDate, DateTime endDate)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return null;
        }

        if (endDate < fromDate)
        {
            return null;
        }

        return await this._repository.GetListByUserIdAsync(userId, fromDate, endDate);
    }
    #endregion
}
