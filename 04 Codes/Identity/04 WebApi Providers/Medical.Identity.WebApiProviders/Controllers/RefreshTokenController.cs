using Medical.Identity.EntityProviders;
using Medical.Identity.LogicProviders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShareLibrary.WebApiProviders;
using System.Threading.Tasks;

namespace Medical.Identity.WebApiProviders;

[Authorize]
public class RefreshTokenController : BaseIdentityWebApiController<RefreshToken, IRefreshTokenLogicProviders, IdentityDbContext>
{
    #region [ CTor ]
    public RefreshTokenController(ILogger<BaseWebApiController<RefreshToken, IRefreshTokenLogicProviders, IdentityDbContext>> logger, IRefreshTokenLogicProviders logicProvider, IdentityLogicContext logicContext) : base(logger, logicProvider, logicContext)
    {
    }
    #endregion
}
