using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
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
            
            options.AddPolicy(RoleConstants.Staff, policy =>
            {
                policy.RequireAssertion(context =>
                    context.User.HasClaim(claims => claims.Type == ClaimTypes.Role && claims.Value.Contains(RoleConstants.Admin)) ||
                    context.User.HasClaim(claims => claims.Type == ClaimTypes.Role && claims.Value.Contains(RoleConstants.DepartmentDirector)) ||
                    context.User.HasClaim(claims => claims.Type == ClaimTypes.Role && claims.Value.Contains(RoleConstants.HRStaff)) ||
                    context.User.HasClaim(claims => claims.Type == ClaimTypes.Role && claims.Value.Contains(RoleConstants.HRManager)) ||
                    context.User.HasClaim(claims => claims.Type == ClaimTypes.Role && claims.Value.Contains(RoleConstants.SalesStaff)) ||
                    context.User.HasClaim(claims => claims.Type == ClaimTypes.Role && claims.Value.Contains(RoleConstants.SalesManager)) ||
                    context.User.HasClaim(claims => claims.Type == ClaimTypes.Role && claims.Value.Contains(RoleConstants.GeneralDirector)) ||
                    context.User.HasClaim(claims => claims.Type == ClaimTypes.Role && claims.Value.Contains(RoleConstants.Staff)));
            });

        });
    }
    #endregion
}
