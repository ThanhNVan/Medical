using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FptUni.BpHostpital.HR.Repositories;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.Repositories;
using System.Linq;

namespace FptUni.BpHostpital.HR;

public class AttendanceRepository : BaseRepository<Attendance, HrDbContext>, IAttendanceRepository
{
    #region [ CTor ]
    public AttendanceRepository(ILogger<AttendanceRepository> logger, IDbContextFactory<HrDbContext> dbContextFactory, IEncriptionProvider encriptionProvider) : base(logger, dbContextFactory, encriptionProvider)
    {
    }
    #endregion

    #region [ Methods - List ]
    public async Task<IList<Attendance>> GetListByUserIdAsync(string userId, DateTime fromDate, DateTime endDate)
    {
        var result = default(List<Attendance>);
        try
        {
            using var dbContext = await this.GetContextAsync();

            result =await (from dbAttendance in dbContext.Attendances
                            where dbAttendance.UserId == userId 
                            && dbAttendance.DateTimeIn >= fromDate
                            && dbAttendance.DateTimeOut <= endDate
                            select dbAttendance).ToListAsync();
            return result;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return result;
        }
    }
    #endregion
}