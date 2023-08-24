using Medical.Identity.EntityProviders;
using ShareLibrary.LogicProviders;
using System.Threading.Tasks;

namespace Medical.Identity.LogicProviders;

public interface IUserLogicProviders : IBaseLogicProvider<User>
{
    #region [ Methods - Sign In ]
    Task<SignInSuccessModel> GetSingleBySignInAsync(SignInModel model);
    #endregion

    #region [ Methods - RenewToken ]
    Task<TokenModel> RenewTokenAsync(TokenModel model);
    #endregion
}
