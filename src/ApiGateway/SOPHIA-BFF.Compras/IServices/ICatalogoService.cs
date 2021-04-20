using SOPHIA_BFF.Compras.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SOPHIA_BFF.Compras.IServices
{
    public interface ICatalogoService
    {
        Task<ItemProdutoDto> ObterPorId(Guid id);
        Task<IEnumerable<ItemProdutoDto>> ObterItens(IEnumerable<Guid> ids);
    }
}
