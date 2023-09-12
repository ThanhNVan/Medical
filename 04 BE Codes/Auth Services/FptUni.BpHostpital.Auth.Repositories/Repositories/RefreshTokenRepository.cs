using FptUni.BpHostpital.Auth.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.Repositories;

namespace FptUni.BpHostpital.Auth.Repositories;

public class RefreshTokenRepository : BaseRepository<RefreshToken, AppDbContext>, IRefreshTokenRepository
{
    #region [ CTor ]
    public RefreshTokenRepository(ILogger<BaseRepository<RefreshToken, AppDbContext>> logger, IDbContextFactory<AppDbContext> dbContextFactory, IEncriptionProvider encriptionProvider) : base(logger, dbContextFactory, encriptionProvider)
    {
    }
    #endregion
}
