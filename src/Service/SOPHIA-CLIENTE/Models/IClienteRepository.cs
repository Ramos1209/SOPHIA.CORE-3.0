using System.Collections.Generic;
using System.Threading.Tasks;
using SOPHIA_Core.Data;

namespace SOPHIA_CLIENTE.Models
{
    public  interface IClienteRepository:IRepository<Cliente>
    {
        void Adicionar(Cliente cliente);
        Task<IEnumerable<Cliente>> ObterTodos();
        Task<Cliente> ObterPorCpf(string cpf);
    }
}
