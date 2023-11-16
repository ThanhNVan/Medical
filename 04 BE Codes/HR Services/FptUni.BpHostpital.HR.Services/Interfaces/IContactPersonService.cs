using System.Collections.Generic;
using System.Threading.Tasks;
using FptUni.BpHostpital.HR.Utils;
using ShareLibrary.Services;

namespace FptUni.BpHostpital.HR.Services;

public interface IContactPersonService : IBaseService<ContactPerson>
{
    #region [ Methods - List ]
    Task<List<ContactPerson>> GetListByUserIdAsync(string userId); 
    #endregion
}
