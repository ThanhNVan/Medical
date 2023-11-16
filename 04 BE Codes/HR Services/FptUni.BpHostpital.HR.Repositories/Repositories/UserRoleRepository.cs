using FptUni.BpHostpital.HR.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.Repositories;
using ShareLibrary.EntityProviders;
using FptUni.BpHospital.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;

namespace FptUni.BpHostpital.HR.Repositories;

public class UserRoleRepository : BaseRepository<UserRole, HrDbContext>, IUserRoleRepository
{
    #region [ CTor ]
    public UserRoleRepository(ILogger<UserRoleRepository> logger, IDbContextFactory<HrDbContext> dbContextFactory, IEncriptionProvider encriptionProvider) : base(logger, dbContextFactory, encriptionProvider)
    {
    }
    #endregion

    #region [ Methods - List ]
    public async Task<IList<UserRoleModel>> GetListByUserIdAsync(string userId)
    {
        var result = default(List<UserRoleModel>);  
        try
        {
            using var dbContext = await this.GetContextAsync();

            result =await  (from dbUserRole in dbContext.UserRoles
                              where dbUserRole.UserId == userId
                              join dbRole in dbContext.Roles
                              on dbUserRole.RoleId equals dbRole.Id
                              join dbDepartment in dbContext.Departments
                              on dbUserRole.DepartmentId equals dbDepartment.Id
                              select new UserRoleModel() { RoleName = dbRole.Name, DepartmentName = dbDepartment.Name }).ToListAsync();
            return result;

        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return result;
        }
    }
    #endregion
}
