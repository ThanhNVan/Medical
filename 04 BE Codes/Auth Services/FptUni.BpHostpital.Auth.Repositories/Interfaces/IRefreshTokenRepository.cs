using FptUni.BpHostpital.Auth.Utils;
using ShareLibrary.Repositories;
using System.Threading.Tasks;

namespace FptUni.BpHostpital.Auth.Repositories;

public interface IRefreshTokenRepository : IBaseRepository<RefreshToken, AppDbContext>
{
    #region [ Methods - Single ]
    Task<RefreshToken> GetSingleByRefreshTokenAsync(string refreshToken);    
    #endregion
}
