using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FptUni.BpHostpital.Auth.Utils;
using FptUni.BpHostpital.Auth.Services;
using FptUni.BpHostpital.Auth.Repositories;

namespace FptUni.BpHostpital.Auth.WebApiHost;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthServiceSqlServerProviders(builder.Configuration);
        builder.Services.AddAuthRepositories();
        builder.Services.AddAuthServices();

        builder.Services.AddAuthenticationProviders(builder.Configuration);

        builder.Services.AddAuthorizationPolicies();
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