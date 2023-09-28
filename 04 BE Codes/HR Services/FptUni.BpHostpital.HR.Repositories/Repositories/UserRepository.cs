using FptUni.BpHostpital.HR.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.Repositories;
using ShareLibrary.EntityProviders;

namespace FptUni.BpHostpital.HR.Repositories;

public class UserRepository : BaseRepository<User, HrDbContext>, IUserRepository
{
    #region [ CTor ]
    public UserRepository(ILogger<UserRepository> logger, IDbContextFactory<HrDbContext> dbContextFactory, IEncriptionProvider encriptionProvider) : base(logger, dbContextFactory, encriptionProvider)
    {
    }
    #endregion
}
