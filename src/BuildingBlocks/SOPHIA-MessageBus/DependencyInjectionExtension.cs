using Microsoft.Extensions.DependencyInjection;
using System;

namespace SOPHIA_MessageBus
{
    public static  class DependencyInjectionExtension
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services, string connection)
        {
            if (string.IsNullOrEmpty(connection)) throw new ArgumentNullException();
            services.AddSingleton<IMessageBus>(new MessageBus(connection));
            return services;
        }
    }
}
