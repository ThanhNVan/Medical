using FptUni.BpHostpital.HR.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.Repositories;

namespace FptUni.BpHostpital.HR.Repositories;

public class ContactPersonRepository : BaseRepository<ContactPerson, HrDbContext>, IContactPersonRepository
{
    #region [ CTor ]
    public ContactPersonRepository(ILogger<BaseRepository<ContactPerson, HrDbContext>> logger, IDbContextFactory<HrDbContext> dbContextFactory, IEncriptionProvider encriptionProvider) : base(logger, dbContextFactory, encriptionProvider)
    {
    }
    #endregion
}
