using FptUni.BpHostpital.Auth.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.Repositories;
using System;
using System.Threading.Tasks;

namespace FptUni.BpHostpital.Auth.Repositories;

public class RefreshTokenRepository : BaseRepository<RefreshToken, AppDbContext>, IRefreshTokenRepository
{
    #region [ CTor ]
    public RefreshTokenRepository(ILogger<RefreshTokenRepository> logger, IDbContextFactory<AppDbContext> dbContextFactory, IEncriptionProvider encriptionProvider) : base(logger, dbContextFactory, encriptionProvider)
    {
    }
    #endregion

    #region [ Methods - Single ]
    public async Task<RefreshToken> GetSingleByRefreshTokenAsync(string refreshToken)
    {
        var result = default(RefreshToken);
        try
        {
            using var context = await this.GetContextAsync();
            result = await context.Set<RefreshToken>().AsNoTracking().FirstOrDefaultAsync(x => x.Token == refreshToken);
            return result;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return result;
        }
    }
    #endregion
}
