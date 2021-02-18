
using Blazored.LocalStorage;
using Blog.Client.Services;
using Blog.Client.Services.Apis;
using Blog.Client.Services.Interface;
using Blog.Client.Utils;
using Blog.Shared.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace Blog.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTExMUAzMTM4MmUzMjJlMzBJaWF3ZHF1ZHBMa1lvQmRCUHZlWThOSWhjNlNSVkxjVE92VGVmZ0F5akQ0PQ==");
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddScoped(sp => new HttpClient 
                { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }.EnableIntercept(sp));
            builder.Services.AddApiAuthorization();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAntDesign();

            builder.Services.AddHttpClientInterceptor();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            builder.Services.AddScoped<RefreshTokenService>();
            builder.Services.AddScoped<HttpInterceptorService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IProfileService, ProfileService>();

            builder.Services.AddScoped<PostApi>(); 

            builder.Services.AddAuthorizationCore(config =>
            {
                config.AddPolicy(Policies.IsAdmin, Policies.IsAdminPolicy());
                config.AddPolicy(Policies.IsUser, Policies.IsUserPolicy());
            });

            builder.Services.AddSyncfusionBlazor();
            await builder.Build().RunAsync();
        }
    }
}
