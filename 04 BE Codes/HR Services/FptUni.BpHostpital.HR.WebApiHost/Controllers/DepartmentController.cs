using ShareLibrary.WebApiProviders;
using FptUni.BpHostpital.HR.Utils;
using FptUni.BpHostpital.HR.Services;
using Microsoft.Extensions.Logging;

namespace FptUni.BpHostpital.HR.WebApiHost;

public class DepartmentController : BaseWebApiController<Department, IDepartmentService, HrDbContext>
{
    #region [ CTor ]
    public DepartmentController(ILogger<BaseWebApiController<Department, IDepartmentService, HrDbContext>> logger, IDepartmentService logicProvider) : base(logger, logicProvider)
    {
    }
    #endregion
}
