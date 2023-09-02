using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Medical.Identity.EntityProviders;

public static class ServiceExtensions
{
    public static void AddIdentitySqlServerProviders(this IServiceCollection services,
              IConfiguration configuration,
              string connectionStringKey = "IdentityConnection")
    {
        var connectionString = configuration.GetConnectionString(connectionStringKey);

        var options = new DbContextOptions<IdentityDbContext>();
        var builder = new DbContextOptionsBuilder<IdentityDbContext>(options);
        builder.UseSqlServer(connectionString);
        builder.EnableSensitiveDataLogging();

        services.AddPooledDbContextFactory<IdentityDbContext>(options =>
        {
            options.UseSqlServer(connectionString,
                sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.EnableRetryOnFailure();
                });
            options.EnableSensitiveDataLogging();
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        var appSettingModel = new AppSettingModel();
        configuration.GetSection("AppSettingModel").Bind(appSettingModel);

        services.AddSingleton(appSettingModel);

        services.AddScoped(p => p.GetRequiredService<IDbContextFactory<IdentityDbContext>>().CreateDbContext());
    }
}
