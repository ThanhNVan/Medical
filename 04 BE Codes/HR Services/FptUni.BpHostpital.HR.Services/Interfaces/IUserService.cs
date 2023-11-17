using System.Collections.Generic;
using System.Threading.Tasks;
using FptUni.BpHostpital.HR.Utils;
using ShareLibrary.Services;

namespace FptUni.BpHostpital.HR.Services;

public interface IUserService : IBaseService<User>
{
    #region [ Methods - List ]
    Task<IList<User>> GetListByOccupationIdAsync(string occupationId);

    Task<IList<User>> GetListByDepartmentIdAsync(string departmentId);
    #endregion
}
