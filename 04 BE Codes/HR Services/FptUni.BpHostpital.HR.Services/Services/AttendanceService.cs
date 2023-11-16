using System.Collections.Generic;
using System.Threading.Tasks;
using System;
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

    #region [ Methods - List ]
    public async Task<IList<Attendance>> GetListByUserIdAsync(string userId, DateTime fromDate, DateTime endDate)
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