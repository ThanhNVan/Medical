using Medical.Identity.EntityProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.DataProviders;

namespace Medical.Identity.DataProviders;

public class UserRoleDataProviders : BaseDataProvider<UserRole, IdentityDbContext>, IUserRoleDataProviders
{
    #region [ CTor ]
    public UserRoleDataProviders(ILogger<BaseDataProvider<UserRole, IdentityDbContext>> logger, IDbContextFactory<IdentityDbContext> dbContextFactory, IEncriptionProvider encriptionProvider) : base(logger, dbContextFactory, encriptionProvider)
    {
    }
    #endregion

    #region [ Methods -  ]
    public async Task<DepartmentRoleModel> GetStringDepartmentAndRoleByUserIdAsync(string userId)
    {
        var result = new DepartmentRoleModel();
        try
        {
            using var context = await this.GetContextAsync();
            var dbResults = await (from userRole in context.UserRoles.AsNoTracking()
                                   join role in context.Roles.AsNoTracking() on userRole.RoleId equals role.Id
                                   join department in context.Departments.AsNoTracking() on userRole.DepartmentId equals department.Id
                                   where userRole.UserId == userId
                                   select new DepartmentRoleModel { Role = role.Name, Department = department.Name }).ToListAsync();

            if (dbResults.Count <= 0 )
            {
                return result;
            }

            for (int i = 0; i < dbResults.Count; i++)
            {
                if (i == 0)
                {
                    result.Role += dbResults[i].Role;
                    result.Department += dbResults[i].Department;
                } else
                {
                    result.Role += ", " + dbResults[i].Role;
                    result.Department += ", " + dbResults[i].Department;
                }
            }

            return result;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return result;
        }
    }
    #endregion
}
