using FptUni.BpHostpital.HR.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.Repositories;
using ShareLibrary.EntityProviders;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace FptUni.BpHostpital.HR.Repositories;

public class ContactPersonRepository : BaseRepository<ContactPerson, HrDbContext>, IContactPersonRepository
{
    #region [ CTor ]
    public ContactPersonRepository(ILogger<ContactPersonRepository> logger, IDbContextFactory<HrDbContext> dbContextFactory, IEncriptionProvider encriptionProvider) : base(logger, dbContextFactory, encriptionProvider)
    {
    }
    #endregion

    #region [ Methods - List ]
    public async Task<List<ContactPerson>> GetListByUserIdAsync(string userId)
    {
        var result = default(List<ContactPerson>);
        try
        {
            using var context = await this.GetContextAsync();
            result = await context.ContactPersons.Where(x => x.UserId == userId).ToListAsync();
            return result;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return result;
        }
    }
    #endregion
}
