using SOPHIA_Core.Comunication;
using SOPHIA_MVC.Models;
using System;
using System.Threading.Tasks;

namespace SOPHIA_MVC.IServices
{
    public interface IComprasBffService
    {

        Task<int> ObterQuantidadeCarrinho();
        Task<CarrinhoViewModel> ObterCarrinho();
        Task<ResponseResult> AdicionarItemCarrinho(ItemCarrinhoViewModel carrinho);
        Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoViewModel carrinho);
        Task<ResponseResult> RemoverItemCarrinho(Guid produtoId);
        Task<ResponseResult> AplicarVoucherCarrinho(string voucher);
    }
}
