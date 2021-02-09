using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SOPHIA_AUTENTICACAO.Data;
using SOPHIA_AUTENTICACAO.Extension;
using SOPHIA_WebApiCore.Identidade;

namespace SOPHIA_AUTENTICACAO.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentiyConfig(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<IdentityMensagensPortugues>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddJwtConfiguration(configuration);

            return services;
        }

       
    }
}
