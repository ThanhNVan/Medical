using Medical.Identity.EntityProviders;
using ShareLibrary.DataProviders;

namespace Medical.Identity.DataProviders;

public interface IRefreshTokenDataProviders : IBaseDataProvider<RefreshToken, IdentityDbContext>
{
}
