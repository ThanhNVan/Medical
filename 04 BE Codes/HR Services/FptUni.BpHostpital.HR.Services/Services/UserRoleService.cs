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
}
