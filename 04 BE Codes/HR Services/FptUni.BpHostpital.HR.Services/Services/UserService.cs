using System.Collections.Generic;
using System.Threading.Tasks;
using FptUni.BpHostpital.HR.Repositories;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.Services;

namespace FptUni.BpHostpital.HR.Services;

public class UserService : BaseServices<User, IUserRepository, HrDbContext>, IUserService
{
    #region [ CTor ]
    public UserService(ILogger<UserService> logger, IUserRepository repository, IEncriptionProvider encriptionProvider) : base(logger, repository, encriptionProvider)
    {
    }
    #endregion

    #region [ Methods - List ]
    public async Task<IList<User>> GetListByOccupationIdAsync(string occupationId)
    {
        if (string.IsNullOrEmpty(occupationId))
        {
            return null;
        }

        return await this._repository.GetListByOccupationIdAsync(occupationId);
    }

    public async Task<IList<User>> GetListByDepartmentIdAsync(string departmentId)
    {
        if (string.IsNullOrEmpty(departmentId))
        {
            return null;
        }

        return await this._repository.GetListByDepartmentIdAsync(departmentId);
    }
    #endregion

    #region [ Methods - Single ]
    public async Task<string> GetUserIdByEmailAsync(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return string.Empty;
        }

        return await this._repository.GetUserIdByEmailAsync(email);
    }
    #endregion
}
