using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Text;

namespace FptUni.BpHostpital.Auth.WebApiHost;

public static class AuthorizationPolicies
{
    #region [ Method - Policies]
    public static void AddAuthorizationPolicies(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy =>
            {
                policy.RequireRole("Admin");
            });

            options.AddPolicy("HR Manager", policy =>
            {
                policy.RequireAssertion(context =>
                    context.User.IsInRole("Admin") ||
                    context.User.IsInRole("General Director") ||
                    context.User.HasClaim(claims => claims.Type == ClaimTypes.Role && claims.Value.Contains("HR Manager")));
            });
        });
    }
    #endregion
}
