﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using SOPHIA_Core.Messeges;

namespace SOPHIA_Core.Mediator
{
   public class MediatorHandler: IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ValidationResult> EnviarComando<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }

        public async Task PublicarEventos<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }
    }
}
