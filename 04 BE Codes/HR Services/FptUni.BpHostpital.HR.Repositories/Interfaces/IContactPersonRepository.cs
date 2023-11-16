using System.Collections.Generic;
using System.Threading.Tasks;
using FptUni.BpHostpital.HR.Utils;
using ShareLibrary.Repositories;

namespace FptUni.BpHostpital.HR.Repositories;

public interface IContactPersonRepository : IBaseRepository<ContactPerson, HrDbContext>
{
    #region [ Methods - List ]
    Task<List<ContactPerson>> GetListByUserIdAsync(string userId);
    #endregion
}
