using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using SOPHIA_MVC.Extensions;
using SOPHIA_MVC.IServices;
using SOPHIA_MVC.Services;
using SOPHIA_MVC.Services.Handler;
using SOPHIA_WebApiCore.Usuario;

namespace SOPHIA_MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IValidationAttributeAdapterProvider, CpfValidationAttributeAdapterProvider>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();



            #region HttpServices

            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();
            services.AddHttpClient<ICarrinhoService, CarrinhoService>();
            services.AddHttpClient<ICatalogoService, CatalogoService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
            #endregion

          
        }
    }
}
