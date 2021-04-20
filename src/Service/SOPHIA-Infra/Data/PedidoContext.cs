using System;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using SOPHIA_Core.Mediator;
using SOPHIA_Core.Messeges;
using System.Linq;
using System.Threading.Tasks;
using SOPHIA_Core.Data;
using SOPHIA_Domain.Pedidos;
using SOPHIA_Domain.Vouchers;

namespace SOPHIA_Infra.Data
{
    public class PedidoContext : DbContext, IUnitOfWork
    {

        private readonly IMediatorHandler _mediatorHandler;

        public PedidoContext(DbContextOptions<PedidoContext> options, IMediatorHandler mediatorHandler)
            : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItems { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.Ignore<Event>();
            modelBuilder.Ignore<ValidationResult>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PedidoContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.HasSequence<int>("MinhaSequencia").StartsAt(1000).IncrementsBy(1);

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            var sucesso = await base.SaveChangesAsync() > 0;
           // if (sucesso) await _mediatorHandler.PublicarEventos(this);

            return sucesso;
        }
    }
}

//    public static class MediatorExtension
//    {
//        public static async Task PublicarEventos<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
//        {
//            var domainEntities = ctx.ChangeTracker
//                .Entries<Entity>()
//                .Where(x => x.Entity.Notificacoes != null && x.Entity.Notificacoes.Any());

//            var domainEvents = domainEntities
//                .SelectMany(x => x.Entity.Notificacoes)
//                .ToList();

//            domainEntities.ToList()
//                .ForEach(entity => entity.Entity.LimparEventos());

//            var tasks = domainEvents
//                .Select(async (domainEvent) => {
//                    await mediator.PublicarEvento(domainEvent);
//                });

//            await Task.WhenAll(tasks);
//        }
//    }
//}
