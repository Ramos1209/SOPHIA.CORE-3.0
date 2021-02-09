using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace SOPHIA_WebApiCore.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        public ICollection<string> Errors = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (EhValida())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                {"Mensagens", Errors.ToArray()}
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(x => x.Errors);
            foreach (var item in errors)
            {
                ProcessamentoErros(item.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                ProcessamentoErros(erro.ErrorMessage);
            }

            return CustomResponse();
        }
        protected bool EhValida()
        {
            return !Errors.Any();
        }

        protected void ProcessamentoErros(string erro)
        {
            Errors.Add(erro);
        }

        protected void LimparProcessamento()
        {
            Errors.Clear();
        }
    }
}
