using FptUni.BpHostpital.HR.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.Repositories;
using ShareLibrary.EntityProviders;

namespace FptUni.BpHostpital.HR.Repositories;

public class ProfileRepository : BaseRepository<Profile, HrDbContext>, IProfileRepository
{
    #region [ CTor ]
    public ProfileRepository(ILogger<ProfileRepository> logger, IDbContextFactory<HrDbContext> dbContextFactory, IEncriptionProvider encriptionProvider) : base(logger, dbContextFactory, encriptionProvider)
    {
    }
    #endregion
}
