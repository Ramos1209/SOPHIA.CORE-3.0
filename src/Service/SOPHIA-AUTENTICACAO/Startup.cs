using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SOPHIA_AUTENTICACAO.Configuration;

namespace SOPHIA_AUTENTICACAO
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

           

            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentiyConfig(Configuration);
            services.AddApiConfiguration();
            services.AddSwaggerConfiguration();
            services.AddMessageBusConfiguration(Configuration);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.USeSwaggerConfiguration();
            app.UseApplicationBuilder(env);

        }
    }
}
