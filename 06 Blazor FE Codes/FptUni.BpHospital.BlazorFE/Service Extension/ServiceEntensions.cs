using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using ShareLibrary.EntityProviders;
using System.IdentityModel.Tokens.Jwt;

namespace FptUni.BpHospital.BlazorFE;

public static class ServiceEntensions
{
    #region [ Methods -  ]
    public static void AddServices(this IServiceCollection services)
    {
        services.AddBlazoredLocalStorage();
        services.AddBlazoredSessionStorage();
        services.AddTransient<AuthenticationStateProvider, AuthenticationProvider>();
        services.AddTransient<JwtSecurityTokenHandler>();
        services.AddTransient<IEncriptionProvider, EncriptionProvider>();
    }
    #endregion

}
