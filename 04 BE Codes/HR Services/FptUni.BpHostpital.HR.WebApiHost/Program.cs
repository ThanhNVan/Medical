using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FptUni.BpHostpital.HR.Utils;
using FptUni.BpHostpital.HR.Repositories;
using FptUni.BpHostpital.HR.Services;

namespace FptUni.BpHostpital.HR.WebApiHost;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddHrServiceSqlServerProviders(builder.Configuration);
        builder.Services.AddHrRepositories();
        builder.Services.AddHrServices();
        builder.Services.AddHrAuthenticationPolicies(builder.Configuration);

        builder.Services.AddHrAuthorizationPolicies();
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