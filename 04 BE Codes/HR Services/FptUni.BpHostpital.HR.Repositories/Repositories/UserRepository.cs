using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.Repositories;

namespace FptUni.BpHostpital.HR.Repositories;

public class UserRepository : BaseRepository<User, HrDbContext>, IUserRepository
{
    #region [ CTor ]
    public UserRepository(ILogger<UserRepository> logger, IDbContextFactory<HrDbContext> dbContextFactory, IEncriptionProvider encriptionProvider) : base(logger, dbContextFactory, encriptionProvider)
    {
    }
    #endregion

    #region [ Methods - List ]
    public async Task<IList<User>> GetListByOccupationIdAsync(string occupationId)
    {
        var result = default(List<User>);
        try
        {
            using var dbContext = await this.GetContextAsync();

            result = await (from dbAttendance in dbContext.Users
                            where dbAttendance.OccupationId == occupationId
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
