using Medical.Identity.DataProviders;
using Medical.Identity.EntityProviders;
using Microsoft.Extensions.Logging;
using ShareLibrary.DataProviders;
using ShareLibrary.LogicProviders;
using System.Threading.Tasks;

namespace Medical.Identity.LogicProviders;

public class UserLogicProviders : BaseLogicProvider<User, IUserDataProviders, IdentityDbContext>, IUserLogicProviders
{
    #region [ CTor ]
    public UserLogicProviders(ILogger<BaseLogicProvider<User, IUserDataProviders, IdentityDbContext>> logger, IUserDataProviders dataProvider, IEncriptionProvider _encriptionProvider) : base(logger, dataProvider, _encriptionProvider)
    {
    }
    #endregion

    #region [ Methods - Override ]
    public async override Task<bool> AddAsync(User entity)
    {
        var passwordHash = this._encriptionProvider.Encrypt(entity.PasswordHash, entity.Id);

        entity.PasswordHash = passwordHash;

        return await base.AddAsync(entity);
    }
    #endregion
}
