using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SOPHIA_MVC.Configuration
{
    public static class IdentityConfig
    {
        public static void AddIdentiyConfig(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt =>
                {
                    opt.LoginPath = "/login";
                    opt.AccessDeniedPath = "/acesso-negado";
                });
        }

        public static void UseIdentiyConfig(this IApplicationBuilder app)
        {

            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
