using Medical.Identity.EntityProviders;
using ShareLibrary.DataProviders;

namespace Medical.Identity.DataProviders;

public interface IUserDataProviders : IBaseDataProvider<User, IdentityDbContext>
{
}
