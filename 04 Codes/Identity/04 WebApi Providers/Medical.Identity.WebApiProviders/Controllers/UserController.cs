using Medical.Identity.EntityProviders;
using Medical.Identity.LogicProviders;
using Microsoft.Extensions.Logging;
using ShareLibrary.WebApiProviders;

namespace Medical.Identity.WebApiProviders;

public class UserController : BaseIdentityWebApiController<User, IUserLogicProviders, IdentityDbContext>
{
    #region [ CTor ]
    public UserController(ILogger<BaseWebApiController<User, IUserLogicProviders, IdentityDbContext>> logger, IUserLogicProviders logicProvider, IdentityLogicContext logicContext) : base(logger, logicProvider, logicContext)
    {
    }
    #endregion
}
