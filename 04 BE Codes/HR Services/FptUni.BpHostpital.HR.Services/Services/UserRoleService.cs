using FptUni.BpHospital.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using FptUni.BpHostpital.HR.Repositories;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.Services;

namespace FptUni.BpHostpital.HR.Services;

public class UserRoleService : BaseServices<UserRole, IUserRoleRepository, HrDbContext>, IUserRoleService
{
    #region [ CTor ]
    public UserRoleService(ILogger<UserRoleService> logger, IUserRoleRepository repository, IEncriptionProvider encriptionProvider) : base(logger, repository, encriptionProvider)
    {
    }
    #endregion

    #region [ Methods - List ]
    public async Task<IList<UserRoleModel>> GetListByUserIdAsync(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return null;
        }

        return await this._repository.GetListByUserIdAsync(userId);
    }
    #endregion
}
