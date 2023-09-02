using Medical.Identity.EntityProviders;
using ShareLibrary.DataProviders;

namespace Medical.Identity.DataProviders;

public interface IDepartmentDataProviders : IBaseDataProvider<Department, IdentityDbContext>
{
}
