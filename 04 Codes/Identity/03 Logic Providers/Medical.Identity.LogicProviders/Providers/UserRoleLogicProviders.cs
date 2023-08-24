using Medical.Identity.DataProviders;
using Medical.Identity.EntityProviders;
using Microsoft.Extensions.Logging;
using ShareLibrary.DataProviders;
using ShareLibrary.LogicProviders;
using System.Threading.Tasks;

namespace Medical.Identity.LogicProviders;

public class UserRoleLogicProviders : BaseLogicProvider<UserRole, IUserRoleDataProviders, IdentityDbContext>, IUserRoleLogicProviders
{
    #region [ CTor ]
    public UserRoleLogicProviders(ILogger<BaseLogicProvider<UserRole, IUserRoleDataProviders, IdentityDbContext>> logger, IUserRoleDataProviders dataProvider, IEncriptionProvider _encriptionProvider) : base(logger, dataProvider, _encriptionProvider)
    {
    }
    #endregion
}
