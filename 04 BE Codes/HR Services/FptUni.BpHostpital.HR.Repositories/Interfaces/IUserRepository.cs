using System.Collections.Generic;
using System.Threading.Tasks;
using FptUni.BpHostpital.HR.Utils;
using ShareLibrary.Repositories;

namespace FptUni.BpHostpital.HR.Repositories;

public interface IUserRepository : IBaseRepository<User, HrDbContext>
{
    #region [ Methods - List ]
    Task<IList<User>> GetListByOccupationIdAsync(string occupationId);  

    Task<IList<User>> GetListByDepartmentIdAsync(string departmentId);
    #endregion

    #region [ Methods - Single ]
    Task<string> GetUserIdByEmailAsync(string email);
    #endregion
}
