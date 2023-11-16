using FptUni.BpHostpital.HR.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.Repositories;
using ShareLibrary.EntityProviders;
using System.Threading.Tasks;
using System;

namespace FptUni.BpHostpital.HR.Repositories;

public class ProfileRepository : BaseRepository<Profile, HrDbContext>, IProfileRepository
{
    #region [ CTor ]
    public ProfileRepository(ILogger<ProfileRepository> logger, IDbContextFactory<HrDbContext> dbContextFactory, IEncriptionProvider encriptionProvider) : base(logger, dbContextFactory, encriptionProvider)
    {
    }
    #endregion

    #region [ Methods - Single ]
    public async Task<Profile> GetSingleByUserIdAsync(string userId)
    {
        var result = default(Profile);
        try
        {
            var dbContext = await base.GetContextAsync();
            result = await dbContext.Profiles.FirstOrDefaultAsync(p => p.UserId == userId);
            return result;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return result;
        }
    }
    #endregion
}
