using Medical.Identity.EntityProviders;
using ShareLibrary.LogicProviders;
using System.Threading.Tasks;

namespace Medical.Identity.LogicProviders;

public interface IRefreshTokenLogicProviders : IBaseLogicProvider<RefreshToken>
{
    #region [ Methods - Get Single ]
    Task<RefreshToken> GetSingleByTokenAsync(string token);
    #endregion
}
