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
}
