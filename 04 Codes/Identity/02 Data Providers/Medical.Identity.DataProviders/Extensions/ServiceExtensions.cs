using Microsoft.Extensions.DependencyInjection;
using ShareLibrary.DataProviders;

namespace Medical.Identity.DataProviders;

public static class ServiceExtensions
{
    #region [ Methods - Add ]
    public static void AddIdentityDataProvider(this IServiceCollection services)
    {
        services.AddTransient<IEncriptionProvider, EncriptionProvider>();
        services.AddTransient<IRefreshTokenDataProviders, RefreshTokenDataProviders>();
        services.AddTransient<IRoleDataProviders, RoleDataProviders>();
        services.AddTransient<IUserDataProviders, UserDataProviders>();
        services.AddTransient<IUserRoleDataProviders, UserRoleDataProviders>();
        services.AddTransient<IDepartmentDataProviders, DepartmentDataProviders>();

        services.AddTransient<IdentityDataContext>();
    }
    #endregion
}
