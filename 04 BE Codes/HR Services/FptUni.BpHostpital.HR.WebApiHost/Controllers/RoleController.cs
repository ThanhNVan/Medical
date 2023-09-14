using FptUni.BpHostpital.HR.Services;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using ShareLibrary.WebApiProviders;

namespace FptUni.BpHostpital.HR.WebApiHost;

public class RoleController : BaseWebApiController<Role, IRoleService, HrDbContext>
{
    #region [ CTor ]
    public RoleController(ILogger<BaseWebApiController<Role, IRoleService, HrDbContext>> logger, IRoleService logicProvider) : base(logger, logicProvider)
    {
    }
    #endregion
}
