using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FptUni.BpHostpital.HR.Utils;
using ShareLibrary.EntityProviders;
using FptUni.BpHospital.Common;

namespace FptUni.BpHospital.HttpClientProviders;

public interface IAttendanceHttpClientProviders : IBaseProvider<Attendance>
{
    #region [ Methods - List ]
    Task<IList<Attendance>> GetListByUserIdAsync(GetByUserIdFromAndEndDateModel model);
    #endregion
}
