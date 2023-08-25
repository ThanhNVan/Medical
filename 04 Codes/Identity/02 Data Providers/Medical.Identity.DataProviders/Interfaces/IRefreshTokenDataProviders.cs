using Medical.Identity.EntityProviders;
using ShareLibrary.DataProviders;

namespace Medical.Identity.DataProviders;

public interface IRefreshTokenDataProviders : IBaseDataProvider<RefreshToken, IdentityDbContext>
{
    #region [ Methods - Get Single ]
    Task<RefreshToken> GetSingleByTokenAsync(string token);
    #endregion
}
