using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SOPHIA_CLIENTE.Services;
using SOPHIA_Core.Utils;
using SOPHIA_MessageBus;

namespace SOPHIA_CLIENTE.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services,
                  IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<RegistrarClienteIntegrationHandler>();
        }

    }
}
