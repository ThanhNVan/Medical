using FptUni.BpHostpital.HR.Services;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.WebApiProviders;

namespace FptUni.BpHostpital.HR.WebApiHost;

[Authorize(Policy = nameof(RoleConstants.HRManager))]
public class RoleController : BaseWebApiController<Role, IRoleService, HrDbContext>
{
    #region [ CTor ]
    public RoleController(ILogger<RoleController> logger, IRoleService logicProvider) : base(logger, logicProvider)
    {
    }
    #endregion
}
