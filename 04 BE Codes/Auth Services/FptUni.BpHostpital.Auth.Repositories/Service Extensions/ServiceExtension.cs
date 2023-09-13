using Microsoft.Extensions.DependencyInjection;

namespace FptUni.BpHostpital.Auth.Repositories;

public static class ServiceExtension
{
    public static void AddAuthRepositories(this IServiceCollection services)
    {
        services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();   
    }
}
