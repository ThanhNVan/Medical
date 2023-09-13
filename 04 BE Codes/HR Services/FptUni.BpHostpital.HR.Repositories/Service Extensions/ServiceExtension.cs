using Microsoft.Extensions.DependencyInjection;

namespace FptUni.BpHostpital.HR.Repositories;

public static class ServiceExtension
{
    public static void AddHrRepositories(this IServiceCollection services)
    {
        services.AddTransient<IContactPersonRepository, ContactPersonRepository>();
        services.AddTransient<IDepartmentRepository, DepartmentRepository>();
        services.AddTransient<IProfileRepository, ProfileRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserRoleRepository, IUserRoleRepository>();


        services.AddTransient<RepositoryContext>();
    }
}
