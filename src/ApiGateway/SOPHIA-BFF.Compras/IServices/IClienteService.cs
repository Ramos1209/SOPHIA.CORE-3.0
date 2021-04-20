using SOPHIA_BFF.Compras.Models;
using System.Threading.Tasks;

namespace SOPHIA_BFF.Compras.IServices
{
    public  interface IClienteService
    {
        Task<EnderecoDTO> ObterEndereco();
    }
}
