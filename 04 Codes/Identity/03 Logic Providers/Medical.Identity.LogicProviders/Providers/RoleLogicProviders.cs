using Medical.Identity.DataProviders;
using Medical.Identity.EntityProviders;
using Microsoft.Extensions.Logging;
using ShareLibrary.DataProviders;
using ShareLibrary.LogicProviders;

namespace Medical.Identity.LogicProviders;

public class RoleLogicProviders : BaseLogicProvider<Role, IRoleDataProviders, IdentityDbContext>, IRoleLogicProviders
{
    #region [ CTor ]
    public RoleLogicProviders(ILogger<BaseLogicProvider<Role, IRoleDataProviders, IdentityDbContext>> logger, IRoleDataProviders dataProvider, IEncriptionProvider _encriptionProvider) : base(logger, dataProvider, _encriptionProvider)
    {
    }
    #endregion
}
