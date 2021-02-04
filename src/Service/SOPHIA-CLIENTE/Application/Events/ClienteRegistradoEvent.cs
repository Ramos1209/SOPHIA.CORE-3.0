using System;
using SOPHIA_Core.Mediator;

namespace SOPHIA_CLIENTE.Application.Events
{
    public class ClienteRegistradoEvent: Event
    {
        public Guid Id { get; set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

        public ClienteRegistradoEvent(Guid id, string nome, string email, string cpf)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }
    }
}
