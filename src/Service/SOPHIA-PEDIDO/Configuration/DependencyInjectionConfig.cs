using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SOPHIA_Core.Mediator;
using SOPHIA_Domain.Pedidos;
using SOPHIA_Domain.Vouchers;
using SOPHIA_Infra.Data;
using SOPHIA_Infra.Data.Repository;
using SOPHIA_PEDIDO.Application.Commands;
using SOPHIA_PEDIDO.Application.Events;
using SOPHIA_PEDIDO.Application.Queries;
using SOPHIA_WebApiCore.Usuario;

namespace SOPHIA_PEDIDO.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            // Commands
             services.AddScoped<IRequestHandler<AdicionarPedidoCommand, ValidationResult>, PedidoCommandHandler>();

            // Events
              services.AddScoped<INotificationHandler<PedidoRealizadoEvent>, PedidoEventHandler>();

            // Application
           services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IVoucherQueries, VoucherQueries>();
            services.AddScoped<IPedidoQueries, PedidoQueries>();

            // Data
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<PedidoContext>();
        }
    }
}
