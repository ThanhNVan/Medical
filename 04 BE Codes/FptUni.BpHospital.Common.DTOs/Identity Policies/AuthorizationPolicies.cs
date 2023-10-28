using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using ShareLibrary.EntityProviders;

namespace FptUni.BpHospital.Common;

public static class AuthorizationPolicies
{
    #region [ Method - Policies]
    public static void AddAuthorizationPolicies(this IServiceCollection services)
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
            
            options.AddPolicy("Staff", policy =>
            {
                policy.RequireAssertion(context =>
                    context.User.HasClaim(claims => claims.Type == ClaimTypes.Role && claims.Value.Contains(RoleConstants.Admin) ||
                                                                                        claims.Value.Contains(RoleConstants.DepartmentDirector) ||
                                                                                        claims.Value.Contains(RoleConstants.HRStaff) ||
                                                                                        claims.Value.Contains(RoleConstants.HRManager) ||
                                                                                        claims.Value.Contains(RoleConstants.SalesStaff) ||
                                                                                        claims.Value.Contains(RoleConstants.SalesManager) ||
                                                                                        claims.Value.Contains(RoleConstants.GeneralDirector) ||
                                                                                        claims.Value.Contains(RoleConstants.Staff)));
            });

        });
    }
    #endregion
}
