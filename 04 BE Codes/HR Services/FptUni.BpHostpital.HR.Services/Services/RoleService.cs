using FptUni.BpHostpital.HR.Repositories;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using ShareLibrary.Repositories;
using ShareLibrary.Services;

namespace FptUni.BpHostpital.HR.Services;

public class RoleService : BaseServices<Role, IRoleRepository, HrDbContext>, IRoleService
{
    #region [ CTor ]
    public RoleService(ILogger<BaseServices<Role, IRoleRepository, HrDbContext>> logger, IRoleRepository repository, IEncriptionProvider encriptionProvider) : base(logger, repository, encriptionProvider)
    {
    }
    #endregion
}
