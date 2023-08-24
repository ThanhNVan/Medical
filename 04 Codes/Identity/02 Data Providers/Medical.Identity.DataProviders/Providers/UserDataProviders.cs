using Medical.Identity.EntityProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.DataProviders;

namespace Medical.Identity.DataProviders;

public class UserDataProviders : BaseDataProvider<User, IdentityDbContext>, IUserDataProviders
{
    #region [ CTor ]
    public UserDataProviders(ILogger<BaseDataProvider<User, IdentityDbContext>> logger, IDbContextFactory<IdentityDbContext> dbContextFactory, IEncriptionProvider encriptionProvider) : base(logger, dbContextFactory, encriptionProvider)
    {
    }
    #endregion

    #region [ Methods -  ]
    public async Task<User> GetSingleByEmailAsync(string email)
    {
        try
        {
            using var context = await this.GetContextAsync();
            var dbResult = await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
            return dbResult;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return null;
        }
    }
    #endregion
}
