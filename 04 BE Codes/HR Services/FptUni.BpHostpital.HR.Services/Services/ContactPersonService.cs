using FptUni.BpHostpital.HR.Repositories;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using ShareLibrary.Repositories;
using ShareLibrary.Services;

namespace FptUni.BpHostpital.HR.Services;

public class ContactPersonService : BaseServices<ContactPerson, IContactPersonRepository, HrDbContext>, IContactPersonService
{
    #region [ CTor ]
    public ContactPersonService(ILogger<BaseServices<ContactPerson, IContactPersonRepository, HrDbContext>> logger, IContactPersonRepository repository, IEncriptionProvider encriptionProvider) : base(logger, repository, encriptionProvider)
    {
    }
    #endregion
}
