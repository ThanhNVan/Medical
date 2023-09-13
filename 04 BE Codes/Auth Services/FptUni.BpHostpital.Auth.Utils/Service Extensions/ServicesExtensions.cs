using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FptUni.BpHostpital.Auth.Utils;

public static class ServicesExtensions
{
    public static void AddAuthServiceSqlServerProviders(this IServiceCollection services,
              IConfiguration configuration,
              string connectionStringKey = "AuthConnection")
    {
        var connectionString = configuration.GetConnectionString(connectionStringKey);
        var options = new DbContextOptions<AppDbContext>();
        var builder = new DbContextOptionsBuilder<AppDbContext>(options);
        builder.UseSqlServer(connectionString);
        builder.EnableSensitiveDataLogging();

        services.AddPooledDbContextFactory<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString,
                sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.EnableRetryOnFailure();
                });
            options.EnableSensitiveDataLogging();
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        var jwtSettingModels = new JwtSettingModels();
        configuration.GetSection("JwtSettingModels").Bind(jwtSettingModels);
        services.AddSingleton(jwtSettingModels);

        services.AddScoped(p => p.GetRequiredService<IDbContextFactory<AppDbContext>>().CreateDbContext());
        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
            options.Password.RequiredLength = 6;
        }).AddEntityFrameworkStores<AppDbContext>()
           .AddDefaultTokenProviders();
    }
}
