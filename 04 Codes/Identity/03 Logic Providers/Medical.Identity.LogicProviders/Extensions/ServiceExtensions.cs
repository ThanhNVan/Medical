using Microsoft.Extensions.DependencyInjection;

namespace Medical.Identity.LogicProviders;

public static class ServiceExtensions
{
    #region [ Methods - Add ]
    public static void AddIdentityLogicProvider(this IServiceCollection services)
    {
        services.AddTransient<IRefreshTokenLogicProviders, RefreshTokenLogicProviders>();
        services.AddTransient<IRoleLogicProviders, RoleLogicProviders>();
        services.AddTransient<IUserLogicProviders, UserLogicProviders>();
        services.AddTransient<IUserRoleLogicProviders, UserRoleLogicProviders>();

        services.AddTransient<IdentityLogicContext>();
    }
    #endregion
}
