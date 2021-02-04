using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SOPHIA_MVC.Extensions;
using SOPHIA_MVC.IServices;
using SOPHIA_MVC.Services;
using SOPHIA_MVC.Services.Handler;

namespace SOPHIA_MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {


            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();
            services.AddHttpClient<ICatalogoService, CatalogoService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
