using FptUni.BpHospital.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using FptUni.BpHostpital.HR.Utils;
using ShareLibrary.Services;

namespace FptUni.BpHostpital.HR.Services;

public interface IUserRoleService : IBaseService<UserRole>
{
    #region [ Methods - List ]
    Task<IList<UserRoleModel>> GetListByUserIdAsync(string userId);
    #endregion
}
