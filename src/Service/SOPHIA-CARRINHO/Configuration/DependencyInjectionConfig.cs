using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SOPHIA_CARRINHO.Data;
using SOPHIA_WebApiCore.Usuario;

namespace SOPHIA_CARRINHO.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
            services.AddScoped<CarrinhoContext>();
        }
    }
}
