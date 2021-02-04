using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SOPHIA_MVC.Models;

namespace SOPHIA_MVC.IServices
{
  public  interface ICatalogoService
    {
        Task<IEnumerable<ProdutoViewModel>> ObterTodos();
        Task<ProdutoViewModel> ObterPorId(Guid id);
    }
}
