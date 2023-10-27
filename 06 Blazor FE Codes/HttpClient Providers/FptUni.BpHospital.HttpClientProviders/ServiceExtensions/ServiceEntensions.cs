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
                clients.BaseAddress = new Uri(configuration["HrClient"]);
            });

        services.AddTransient<IAuthenticationHttpClientProviders, AuthenticationHttpClientProviders>();

        services.AddTransient<HttpClientContext>();
    }
    #endregion

}
