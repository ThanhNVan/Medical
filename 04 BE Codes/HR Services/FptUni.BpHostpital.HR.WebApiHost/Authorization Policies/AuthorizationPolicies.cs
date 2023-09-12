using Microsoft.Extensions.DependencyInjection;
using ShareLibrary.EntityProviders;
using System.Security.Claims;

namespace FptUni.BpHostpital.HR.WebApiHost;

public static class AuthorizationPolicies
{
    #region [ Method - Policies]
    public static void AddHrAuthorizationPolicies(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy(RoleConstants.Admin, policy =>
            {
                policy.RequireRole(RoleConstants.Admin);
            });

            options.AddPolicy(RoleConstants.HRManager, policy =>
            {
                policy.RequireAssertion(context =>
                    context.User.IsInRole(RoleConstants.Admin) ||
                    context.User.HasClaim(claims => claims.Type == ClaimTypes.Role && claims.Value.Contains(RoleConstants.GeneralDirector)) ||
                    context.User.HasClaim(claims => claims.Type == ClaimTypes.Role && claims.Value.Contains(RoleConstants.HRManager)));
            });
        });
    }
    #endregion
}
