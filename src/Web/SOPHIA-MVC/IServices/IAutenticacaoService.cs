using SOPHIA_MVC.Models;
using System.Threading.Tasks;

namespace SOPHIA_MVC.IServices
{
    public interface IAutenticacaoService
    {
            Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin);

            Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro);
        
    }
}
