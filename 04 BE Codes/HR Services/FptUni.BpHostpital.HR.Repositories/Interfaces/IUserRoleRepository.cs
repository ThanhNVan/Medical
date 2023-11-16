using System.Collections.Generic;
using System.Threading.Tasks;
using FptUni.BpHospital.Common;
using FptUni.BpHostpital.HR.Utils;
using ShareLibrary.Repositories;

namespace FptUni.BpHostpital.HR.Repositories;

public interface IUserRoleRepository : IBaseRepository<UserRole, HrDbContext>
{
    #region [ Methods - List ]
    Task<IList<UserRoleModel>> GetListByUserIdAsync(string userId);
    #endregion
}
