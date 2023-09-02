using Medical.Identity.DataProviders;
using Medical.Identity.EntityProviders;
using Microsoft.Extensions.Logging;
using ShareLibrary.DataProviders;
using ShareLibrary.LogicProviders;

namespace Medical.Identity.LogicProviders;

public class DepartmentLogicProviders : BaseLogicProvider<Department, IDepartmentDataProviders, IdentityDbContext>, IDepartmentLogicProviders
{
    #region [ CTor ]
    public DepartmentLogicProviders(ILogger<BaseLogicProvider<Department, IDepartmentDataProviders, IdentityDbContext>> logger, IDepartmentDataProviders dataProvider, IEncriptionProvider encriptionProvider) : base(logger, dataProvider, encriptionProvider)
    {
    }
    #endregion
}
