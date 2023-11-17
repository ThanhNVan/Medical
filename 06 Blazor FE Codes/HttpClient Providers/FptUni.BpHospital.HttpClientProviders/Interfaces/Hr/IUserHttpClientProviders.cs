using System.Collections.Generic;
using System.Threading.Tasks;
using FptUni.BpHostpital.HR.Utils;
using ShareLibrary.EntityProviders;

namespace FptUni.BpHospital.HttpClientProviders;

public interface IUserHttpClientProviders : IBaseProvider<User>
{
    #region [ Methods - List ]
    Task<IList<User>> GetListByOccupationIdAsync(string occupationId);

    Task<IList<User>> GetListByDepartmentIdAsync(string departmentId);
    #endregion
}
