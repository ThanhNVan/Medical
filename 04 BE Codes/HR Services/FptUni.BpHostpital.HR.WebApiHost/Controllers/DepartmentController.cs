using ShareLibrary.WebApiProviders;
using FptUni.BpHostpital.HR.Utils;
using FptUni.BpHostpital.HR.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using ShareLibrary.EntityProviders;

namespace FptUni.BpHostpital.HR.WebApiHost;

[Authorize(Policy = nameof(RoleConstants.HRManager))]
public class DepartmentController : BaseWebApiController<Department, IDepartmentService, HrDbContext>
{
    #region [ CTor ]
    public DepartmentController(ILogger<DepartmentController> logger, IDepartmentService logicProvider) : base(logger, logicProvider)
    {
    }
    #endregion
}
