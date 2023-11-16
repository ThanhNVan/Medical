using FptUni.BpHospital.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using FptUni.BpHostpital.HR.Utils;
using ShareLibrary.Repositories;
using System;

namespace FptUni.BpHostpital.HR.Repositories;

public interface IAttendanceRepository : IBaseRepository<Attendance, HrDbContext>
{
    #region [ Methods - List ]
    Task<IList<Attendance>> GetListByUserIdAsync(string userId, DateTime fromDate, DateTime endDate);
    #endregion
}
