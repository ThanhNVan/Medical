using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FptUni.BpHospital.HttpClientProviders;

public static class ServiceEntensions
{
    #region [ Methods -  ]
    public static void AddHttpClientProviders(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient(
            RoutingUrl.AuthClient, clients =>
            {
                clients.BaseAddress = new Uri(configuration["AuthClient"]);
            });

        services.AddHttpClient(
            RoutingUrl.HrClient, clients =>
            {
                clients.BaseAddress = new Uri(configuration["HrClient"]);
            });
        
        services.AddHttpClient(
            RoutingUrl.MedicineClient, clients =>
            {
                clients.BaseAddress = new Uri(configuration["MedicineClient"]);
            });

        services.AddTransient<IAuthenticationHttpClientProviders, AuthenticationHttpClientProviders>();
        services.AddTransient<IContactPersonHttpClientProviders, ContactPersonHttpClientProviders>();
        services.AddTransient<IDepartmentHttpClientProviders, DepartmentHttpClientProviders>();
        services.AddTransient<IOccupationHttpClientProviders, OccupationHttpClientProviders>();
        services.AddTransient<IProfileHttpClientProviders, ProfileHttpClientProviders>();
        services.AddTransient<IRoleHttpClientProviders, RoleHttpClientProviders>();
        services.AddTransient<IUserHttpClientProviders, UserHttpClientProviders>();
        services.AddTransient<IUserRoleHttpClientProviders, UserRoleHttpClientProviders>();
        services.AddTransient<IAttendanceHttpClientProviders, AttendanceHttpClientProviders>();
        services.AddTransient<ILeaveRequestHttpClientProviders, LeaveRequestHttpClientProviders>();

        services.AddTransient<HttpClientContext>();
    }
    #endregion

}
