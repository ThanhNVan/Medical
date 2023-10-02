using FptUni.BpHostpital.HR.Repositories;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.Services;

namespace FptUni.BpHostpital.HR.Services;

public class ContactPersonService : BaseServices<ContactPerson, IContactPersonRepository, HrDbContext>, IContactPersonService
{
    #region [ CTor ]
    public ContactPersonService(ILogger<ContactPersonService> logger, IContactPersonRepository repository, IEncriptionProvider encriptionProvider) : base(logger, repository, encriptionProvider)
    {
    }
    #endregion
}
