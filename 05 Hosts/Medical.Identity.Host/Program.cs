using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Medical.Identity.EntityProviders;
using Medical.Identity.DataProviders;
using Medical.Identity.LogicProviders;
using Medical.Identity.WebApiProviders;

namespace Medical.Identity.Host;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddIdentitySqlServerProviders(builder.Configuration);
        builder.Services.AddIdentityDataProvider();
        builder.Services.AddIdentityLogicProvider();
        builder.Services.AddAuthenticationProviders(builder.Configuration);
        builder.Services.AddAuthorizationProviders();
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}