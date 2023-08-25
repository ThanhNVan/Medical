using Medical.Identity.EntityProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.DataProviders;

namespace Medical.Identity.DataProviders;

public class RefreshTokenDataProviders : BaseDataProvider<RefreshToken, IdentityDbContext>, IRefreshTokenDataProviders
{
    #region [ CTor ]
    public RefreshTokenDataProviders(ILogger<BaseDataProvider<RefreshToken, IdentityDbContext>> logger, IDbContextFactory<IdentityDbContext> dbContextFactory, IEncriptionProvider encriptionProvider) : base(logger, dbContextFactory, encriptionProvider)
    {
    }
    #endregion

    #region [ Methods - Get Single ]
    public async Task<RefreshToken> GetSingleByTokenAsync(string token)
    {
        try
        {
            using var context = await this.GetContextAsync();
            var result = await context.RefreshTokens.AsNoTracking().FirstOrDefaultAsync(t => t.Token == token);
            return result;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return null;
        }
    }
    #endregion
}
