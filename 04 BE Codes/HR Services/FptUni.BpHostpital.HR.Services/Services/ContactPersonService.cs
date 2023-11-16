using System.Collections.Generic;
using System.Threading.Tasks;
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

    #region [ Methods - List ]
    public async Task<List<ContactPerson>> GetListByUserIdAsync(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return null;
        }

        return await this._repository.GetListByUserIdAsync(userId);
    }
    #endregion
}
