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

            result = await (from dbUser in dbContext.Users
                            where dbUser.OccupationId == occupationId
                            && dbUser.IsDeleted == false
                            select dbUser).ToListAsync();
            return result;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return result;
        }
    }
    
    public async Task<IList<User>> GetListByDepartmentIdAsync(string departmentId)
    {
        var result = default(List<User>);
        try
        {
            using var dbContext = await this.GetContextAsync();

            result = await (from dbUser in dbContext.Users
                            where dbUser.IsDeleted == false
                            join dbUserRole in dbContext.UserRoles
                            on dbUser.Id equals dbUserRole.UserId
                            join dbDepartment in dbContext.Departments
                            on dbUserRole.DepartmentId equals dbDepartment.Id
                            where departmentId == dbDepartment.Id
                            select dbUser).ToListAsync();
            return result;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return result;
        }
    }
    #endregion
}
