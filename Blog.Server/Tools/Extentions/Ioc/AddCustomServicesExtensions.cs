//using AuthChrissainty.Server.Services;
//using AuthChrissainty.Server.Services.Identity;
//using AuthChrissainty.Server.Services.Identity.Imp;
//using AuthChrissainty.Shared.Identity;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Security.Principal;
//using System.Threading.Tasks;

//namespace AuthChrissainty.Server.Ioc
//{
//    public static class AddCustomServicesExtensions
//    {
//        public static IServiceCollection AddCustomServices(this IServiceCollection services)
//        {
//            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//            services.AddScoped<IPrincipal>(provider =>
//                provider.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.User ?? ClaimsPrincipal.Current);

//            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationClaimsPrincipalFactory>();
//            services.AddScoped<UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>, ApplicationClaimsPrincipalFactory>();

//            services.AddScoped<IApplicationRoleManager, ApplicationRoleManager>();
//            services.AddScoped<RoleManager<ApplicationRole>, ApplicationRoleManager>();

//            return services;
//        }
//    }
//}
