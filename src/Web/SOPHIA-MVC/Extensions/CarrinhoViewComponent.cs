using Microsoft.AspNetCore.Mvc;
using SOPHIA_MVC.IServices;
using System.Threading.Tasks;

namespace SOPHIA_MVC.Extensions
{
    public class CarrinhoViewComponent:ViewComponent
    {
        private readonly IComprasBffService _carrinhoService;

        public CarrinhoViewComponent(IComprasBffService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _carrinhoService.ObterQuantidadeCarrinho());
        }
    }
}
