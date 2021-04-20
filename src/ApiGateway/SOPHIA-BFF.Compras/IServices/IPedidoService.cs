using System.Threading.Tasks;
using SOPHIA_BFF.Compras.Models;

namespace SOPHIA_BFF.Compras.IServices
{
    public interface IPedidoService
    {
        Task<VoucherDTO> ObterVoucherPorCodigo(string codigo);
    }

   
}
