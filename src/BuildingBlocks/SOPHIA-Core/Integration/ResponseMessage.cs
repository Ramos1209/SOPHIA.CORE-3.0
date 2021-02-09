using FluentValidation.Results;
using SOPHIA_Core.Messeges;

namespace SOPHIA_Core.Integration
{
    public class ResponseMessage: Messege
    {
        public ValidationResult ValidationResult { get; set; }

        public ResponseMessage(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}
