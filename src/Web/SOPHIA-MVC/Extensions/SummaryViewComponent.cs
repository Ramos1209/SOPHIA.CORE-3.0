using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SOPHIA_MVC.Extensions
{
    public class SummaryViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvoKeAsync()
        {
            return View();
        }
    }
}
