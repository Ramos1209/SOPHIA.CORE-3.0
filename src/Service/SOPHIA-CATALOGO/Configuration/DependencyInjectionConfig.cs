using Microsoft.Extensions.DependencyInjection;
using SOPHIA_CATALOGO.Data;
using SOPHIA_CATALOGO.Data.Repository;
using SOPHIA_CATALOGO.Models;

namespace SOPHIA_CATALOGO.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<CatalogoContext>();
        }
    }
}
