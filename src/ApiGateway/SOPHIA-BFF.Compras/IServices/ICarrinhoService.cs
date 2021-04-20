using System;
using System.Threading.Tasks;
using SOPHIA_BFF.Compras.Models;
using SOPHIA_Core.Comunication;

namespace SOPHIA_BFF.Compras.IServices
{
    public  interface ICarrinhoService
    {
        Task<CarrinhoDto> ObterCarrinho();
        Task<ResponseResult> AdicionarItenCarrinho(ItemCarrinhoDto produto);
        Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId ,ItemCarrinhoDto carrinho);
        Task<ResponseResult> RemoverItemCarrinho(Guid produtoId);
        Task<ResponseResult> AplicarVoucherCarrinho(VoucherDTO voucher);
    }
}
