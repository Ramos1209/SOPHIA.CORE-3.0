using System.Net;
using Microsoft.AspNetCore.Mvc;
using SOPHIA_WebApiCore.Controllers;
using System.Threading.Tasks;
using SOPHIA_PEDIDO.Application.DTO;
using SOPHIA_PEDIDO.Application.Queries;

namespace SOPHIA_PEDIDO.Controllers
{
    public class VoucherController : MainController
    {
      
        private readonly IVoucherQueries _voucherQueries;
        public VoucherController(IVoucherQueries voucherQueries)
        {
            _voucherQueries = voucherQueries;
        }

        [HttpGet("voucher/{codigo}")]
        [ProducesResponseType(typeof(VoucherDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ObterPorCodigo(string codigo)
        {
            if (string.IsNullOrEmpty(codigo)) return NotFound();

            var voucher = await _voucherQueries.ObterVoucherPorCodigo(codigo);

            return voucher == null ? NotFound() : CustomResponse(voucher);
        }
    }
}
