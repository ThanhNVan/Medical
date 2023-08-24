﻿using Medical.Identity.EntityProviders;
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
    public async Task<string> GetStringRoleByUserIdAsync(string userId)
    {
        var result = string.Empty;
        try
        {
            using var context = await this.GetContextAsync();
            var dbResults = await (from userRole in context.UserRoles.AsNoTracking()
                                   join role in context.Roles.AsNoTracking() on userRole.RoleId equals role.Id
                                   where userRole.UserId == userId
                                   select role).ToListAsync();

            if (dbResults.Count <= 0 )
            {
                return "Staff";
            }

            for (int i = 0; i < dbResults.Count; i++)
            {
                if (i == 0)
                {
                    result += dbResults[i].Name;
                } else
                {
                    result += ", " + dbResults[i].Name;
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
