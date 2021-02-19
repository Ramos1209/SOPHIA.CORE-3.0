using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SOPHIA_WebApiCore.Identidade;

namespace SOPHIA_AUTENTICACAO.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection service)
        {
            service.AddControllers();
            return service;
        }

        public static IApplicationBuilder UseApplicationBuilder(this IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseRouting();
            app.UseAuthConfiguration();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            return app;
        }
    }
}
