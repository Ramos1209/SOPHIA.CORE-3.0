﻿using System;
using FluentValidation;
using FluentValidation.Results;
using SOPHIA_Core.Messeges;

namespace SOPHIA_CLIENTE.Application.Commands
{
    public class RegistrarClienteCommand: Command
    {
        public Guid Id { get; set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

        public RegistrarClienteCommand(Guid id, string nome, string  email, string cpf)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }

        public override bool EstaValido()
        {
            ValidationResult = new RegistrarClienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        public class RegistrarClienteValidation : AbstractValidator<RegistrarClienteCommand>
        {
            public RegistrarClienteValidation()
            {
                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do cliente inválido");

                RuleFor(c => c.Nome)
                    .NotEmpty()
                    .WithMessage("O nome do cliente não foi informado");

                RuleFor(c => c.Cpf)
                    .Must(TerCpfValido)
                    .WithMessage("O CPF informado não é válido.");

                RuleFor(c => c.Email)
                    .Must(TerEmailValido)
                    .WithMessage("O e-mail informado não é válido.");
            }

            protected static bool TerCpfValido(string cpf)
            {
                return SOPHIA_Core.DomainObjects.Cpf.Validar(cpf);
            }

            protected static bool TerEmailValido(string email)
            {
                return SOPHIA_Core.DomainObjects.Email.Validar(email);
            }
        }
    }
}