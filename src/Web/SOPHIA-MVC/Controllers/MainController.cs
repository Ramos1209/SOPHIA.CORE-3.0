using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SOPHIA_MVC.Models;

namespace SOPHIA_MVC.Controllers
{
    public class MainController: Controller
    {
        protected bool ResponsePossuiErros(ResponseResult response)
        {
            if (response != null && response.Erros.Mensagens.Any())
            {
                foreach (var mensagem in response.Erros.Mensagens)
                {
                    ModelState.AddModelError(string.Empty, mensagem);
                }

                return true;
            }

            return false;
        }
        protected void AdicionarErroValidacao(string mensagem)
        {
            ModelState.AddModelError(string.Empty, mensagem);
        }

        protected bool OperacaoValida()
        {
            return ModelState.ErrorCount == 0;
        }
    }
}
