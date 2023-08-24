using Medical.Identity.DataProviders;
using Medical.Identity.EntityProviders;
using Microsoft.Extensions.Logging;
using ShareLibrary.DataProviders;
using ShareLibrary.LogicProviders;

namespace Medical.Identity.LogicProviders;

public class RefreshTokenLogicProviders : BaseLogicProvider<RefreshToken, IRefreshTokenDataProviders, IdentityDbContext>, IRefreshTokenLogicProviders
{
    #region [ CTor ]
    public RefreshTokenLogicProviders(ILogger<BaseLogicProvider<RefreshToken, IRefreshTokenDataProviders, IdentityDbContext>> logger, IRefreshTokenDataProviders dataProvider, IEncriptionProvider _encriptionProvider) : base(logger, dataProvider, _encriptionProvider)
    {
    }
    #endregion
}
