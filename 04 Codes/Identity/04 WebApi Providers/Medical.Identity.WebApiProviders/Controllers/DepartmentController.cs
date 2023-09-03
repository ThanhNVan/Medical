using Medical.Identity.EntityProviders;
using Medical.Identity.LogicProviders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using ShareLibrary.WebApiProviders;

namespace Medical.Identity.WebApiProviders;

[Authorize(Policy = "HR Manager")]
public class DepartmentController : BaseIdentityWebApiController<Department, IDepartmentLogicProviders, IdentityDbContext>
{
    #region [ CTor ]
    public DepartmentController(ILogger<BaseWebApiController<Department, IDepartmentLogicProviders, IdentityDbContext>> logger, IDepartmentLogicProviders logicProvider, IdentityLogicContext logicContext) : base(logger, logicProvider, logicContext)
    {
    }
    #endregion
}
