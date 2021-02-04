using FluentValidation.Results;
using System;
using MediatR;

namespace SOPHIA_Core.Messeges
{
    public abstract class Command: Messege,IRequest<ValidationResult>
    {

      
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool EstaValido()
        {
            throw new NotImplementedException();
        }
    }
   
}
