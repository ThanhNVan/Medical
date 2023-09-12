using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FptUni.BpHostpital.HR.Utils;

public static class ServicesExtensions
{
    public static void AddHrServiceSqlServerProviders(this IServiceCollection services,
             IConfiguration configuration,
             string connectionStringKey = "HrConnection")
    {
        var connectionString = configuration.GetConnectionString(connectionStringKey);
        var options = new DbContextOptions<HrDbContext>();
        var builder = new DbContextOptionsBuilder<HrDbContext>(options);
        builder.UseSqlServer(connectionString);
        builder.EnableSensitiveDataLogging();

        services.AddPooledDbContextFactory<HrDbContext>(options =>
        {
            options.UseSqlServer(connectionString,
                sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.EnableRetryOnFailure();
                });
            options.EnableSensitiveDataLogging();
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        services.AddScoped(p => p.GetRequiredService<IDbContextFactory<HrDbContext>>().CreateDbContext());
    }
}
