using System.Collections.Generic;
using System.Threading.Tasks;
using FptUni.BpHostpital.HR.Utils;
using ShareLibrary.EntityProviders;

namespace FptUni.BpHospital.HttpClientProviders;

public interface IContactPersonHttpClientProviders : IBaseProvider<ContactPerson>
{
    #region [ Methods - List ]
    Task<IList<ContactPerson>> GetListByUserIdAsync(string userId);
    #endregion
}

