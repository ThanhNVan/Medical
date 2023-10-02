using Microsoft.Extensions.DependencyInjection;
using ShareLibrary.EntityProviders;

namespace FptUni.BpHostpital.Auth.Services;

public static class ServiceExtension
{
    public static void AddAuthServices(this IServiceCollection services) { 
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IEncriptionProvider, EncriptionProvider>();
    }
}
