using FptUni.BpHostpital.Auth.Utils;
using ShareLibrary.Repositories;

namespace FptUni.BpHostpital.Auth.Repositories;

public interface IRefreshTokenRepository : IBaseRepository<RefreshToken, AppDbContext>
{
}
