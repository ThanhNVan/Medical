using FptUni.BpHostpital.HR.Repositories;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using ShareLibrary.Repositories;
using ShareLibrary.Services;

namespace FptUni.BpHostpital.HR.Services;

public class DepartmentService : BaseServices<Department, IDepartmentRepository, HrDbContext>, IDepartmentService
{
    #region [ CTor ]
    public DepartmentService(ILogger<DepartmentService> logger, IDepartmentRepository repository, IEncriptionProvider encriptionProvider) : base(logger, repository, encriptionProvider)
    {
    }
    #endregion
}
