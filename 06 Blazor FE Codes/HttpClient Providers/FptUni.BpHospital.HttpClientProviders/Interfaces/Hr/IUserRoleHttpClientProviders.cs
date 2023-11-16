using FptUni.BpHospital.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using FptUni.BpHostpital.HR.Utils;
using ShareLibrary.EntityProviders;

namespace FptUni.BpHospital.HttpClientProviders;

public interface IUserRoleHttpClientProviders : IBaseProvider<UserRole>
{
    #region [ Methods - List ]
    Task<IList<UserRoleModel>> GetListByUserIdAsync(string userId);
    #endregion
}
