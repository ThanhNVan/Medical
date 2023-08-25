using Medical.Identity.DataProviders;
using Medical.Identity.EntityProviders;
using Microsoft.Extensions.Logging;
using ShareLibrary.DataProviders;
using ShareLibrary.LogicProviders;
using System.Threading.Tasks;

namespace Medical.Identity.LogicProviders;

public class RefreshTokenLogicProviders : BaseLogicProvider<RefreshToken, IRefreshTokenDataProviders, IdentityDbContext>, IRefreshTokenLogicProviders
{
    #region [ CTor ]
    public RefreshTokenLogicProviders(ILogger<BaseLogicProvider<RefreshToken, IRefreshTokenDataProviders, IdentityDbContext>> logger, IRefreshTokenDataProviders dataProvider, IEncriptionProvider _encriptionProvider) : base(logger, dataProvider, _encriptionProvider)
    {
    }
    #endregion

    #region [ Methods - Get Single ]
    public async Task<RefreshToken> GetSingleByTokenAsync(string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            return null;
        }

        return await this._dataProvider.GetSingleByTokenAsync(token);
    }
    #endregion
}
