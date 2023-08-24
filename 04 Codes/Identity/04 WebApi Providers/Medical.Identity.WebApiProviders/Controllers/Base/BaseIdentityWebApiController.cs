using Medical.Identity.LogicProviders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.LogicProviders;
using ShareLibrary.WebApiProviders;

namespace Medical.Identity.WebApiProviders;

[ApiController]
[Route("Api/V1/[controller]")]
public abstract class BaseIdentityWebApiController<TEntity, TLogicProvider, TContext> : BaseWebApiController<TEntity, TLogicProvider, TContext>
    where TEntity : BaseEntity
    where TContext : DbContext
    where TLogicProvider : IBaseLogicProvider<TEntity>
{
    #region [ Properties ]
    protected readonly IdentityLogicContext _logicContext;
    #endregion

    #region [ Properties ]
    public BaseIdentityWebApiController(ILogger<BaseWebApiController<TEntity, TLogicProvider, TContext>> logger, TLogicProvider logicProvider, IdentityLogicContext logicContext) : base(logger, logicProvider)
    {
        this._logicContext = logicContext;
    }
    #endregion

}
