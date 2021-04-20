using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SOPHIA_CLIENTE.Application.Commands;
using SOPHIA_CLIENTE.Application.Events;
using SOPHIA_CLIENTE.Data;
using SOPHIA_CLIENTE.Data.Repository;
using SOPHIA_CLIENTE.Models;
using SOPHIA_Core.Mediator;

namespace SOPHIA_CLIENTE.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();

            services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ClientesContext>();


        }
    }
}
