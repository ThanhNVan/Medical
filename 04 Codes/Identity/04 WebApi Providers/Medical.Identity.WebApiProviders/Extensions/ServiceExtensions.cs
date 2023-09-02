using Medical.Identity.EntityProviders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Text;

namespace Medical.Identity.WebApiProviders;

public static class ServiceExtensions
{
    public static void AddAuthenticationProviders(this IServiceCollection services,
              IConfiguration configuration)
    {
        var secretKey = configuration["AppSettingModel:SecretKey"];
        var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                ClockSkew = TimeSpan.Zero
            };
        });
    }

    public static void AddAuthorizationProviders(this IServiceCollection services)
    {
        services.AddAuthorization(options => {
            options.AddPolicy(IdentityRole.Admin, policy =>
            {
                policy.RequireRole(IdentityRole.Admin);
            });

            options.AddPolicy(IdentityRole.Manager, policy =>
            {
                policy.RequireAssertion(context =>
                    context.User.IsInRole(IdentityRole.Admin) ||
                    context.User.HasClaim(claims => claims.Type == IdentityDepartment.Department && claims.Value.Contains( IdentityDepartment.HR) ) && context.User.IsInRole(IdentityRole.Manager));
            });
        });
    }
}
