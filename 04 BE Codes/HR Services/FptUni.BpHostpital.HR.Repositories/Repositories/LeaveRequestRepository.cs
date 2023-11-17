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
using FptUni.BpHospital.Common;

namespace FptUni.BpHostpital.HR;

public class LeaveRequestRepository : BaseRepository<LeaveRequest, HrDbContext>, ILeaveRequestRepository
{
    #region [ CTor ]
    public LeaveRequestRepository(ILogger<LeaveRequestRepository> logger, IDbContextFactory<HrDbContext> dbContextFactory, IEncriptionProvider encriptionProvider) : base(logger, dbContextFactory, encriptionProvider)
    {
    }
    #endregion

    #region [ Methods - List ]
    public async Task<IList<LeaveRequest>> GetListByUserIdAsync(string userId, DateTime fromDate, DateTime endDate)
    {
        var result = default(List<LeaveRequest>);
        try
        {
            using var dbContext = await this.GetContextAsync();

            result = await (from dbLeaveRequest in dbContext.LeaveRequests
                            where dbLeaveRequest.UserId == userId
                            && dbLeaveRequest.CreatedAt >= fromDate
                            && dbLeaveRequest.CreatedAt <= endDate
                            && dbLeaveRequest.LeaveState != LeaveState.Cancelled
                            select dbLeaveRequest).ToListAsync();
            return result;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return result;
        }
    }

    public async Task<IList<LeaveRequest>> GetListProcessingStateAsync()
    {
        var result = default(List<LeaveRequest>);
        try
        {
            using var dbContext = await this.GetContextAsync();

            result = await (from dbLeaveRequest in dbContext.LeaveRequests
                            where dbLeaveRequest.LeaveState == LeaveState.Processing
                            select dbLeaveRequest).ToListAsync();
            return result;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return result;
        }
    }
    #endregion

    #region [ Methods - Update ]
    public async Task<bool> ApproveAsync(string leaveRequestId)
    {
        var result = default(bool);
        try
        {
            using var dbContext = await this.GetContextAsync();
            var dbEntity = await dbContext.LeaveRequests.FirstOrDefaultAsync(x => x.Id == leaveRequestId);
            if (dbEntity is not null)
            {
                dbEntity.LastUpdatedAt = DateTime.UtcNow;
                dbEntity.LeaveState = LeaveState.Approved;
                dbContext.Update(dbEntity);
                await dbContext.SaveChangesAsync();

                return true;
            } else
            {
                return false;
            }
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return result;
        }
    }

    public async Task<bool> DenyAsync(string leaveRequestId)
    {
        var result = default(bool);
        try
        {
            using var dbContext = await this.GetContextAsync();
            var dbEntity = await dbContext.LeaveRequests.FirstOrDefaultAsync(x => x.Id == leaveRequestId);
            if (dbEntity is not null)
            {
                dbEntity.LastUpdatedAt = DateTime.UtcNow;
                dbEntity.LeaveState = LeaveState.Denied;
                dbContext.Update(dbEntity);
                await dbContext.SaveChangesAsync();

                return true;
            } else
            {
                return false;
            }
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return result;
        }
    }
    #endregion
}
