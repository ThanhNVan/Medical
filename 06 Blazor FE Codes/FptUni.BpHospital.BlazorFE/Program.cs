using FptUni.BpHospital.HttpClientProviders;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Syncfusion.Blazor;
using FptUni.BpHospital.Common;

namespace FptUni.BpHospital.BlazorFE;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddSyncfusionBlazor();
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddHttpClientProviders(builder.Configuration);
        builder.Services.AddAuthenticationPolicies(builder.Configuration);
        builder.Services.AddAuthorizationCorePolicies();
        builder.Services.AddServices();

        var app = builder.Build();

        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(builder.Configuration["SyncfusionKey"]);
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization(); 
        app.UseStaticFiles();

        app.UseRouting();

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.Run();
    }
}