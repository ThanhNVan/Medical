using Medical.Identity.EntityProviders;
using Medical.Identity.LogicProviders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using ShareLibrary.WebApiProviders;

namespace Medical.Identity.WebApiProviders;

[Authorize(Policy = nameof(IdentityRole.Admin))]
public class RoleController : BaseIdentityWebApiController<Role, IRoleLogicProviders, IdentityDbContext>
{
    public RoleController(ILogger<BaseWebApiController<Role, IRoleLogicProviders, IdentityDbContext>> logger, IRoleLogicProviders logicProvider, IdentityLogicContext logicContext) : base(logger, logicProvider, logicContext)
    {
    }
}
