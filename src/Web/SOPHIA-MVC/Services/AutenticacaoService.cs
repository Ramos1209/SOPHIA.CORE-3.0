using Microsoft.Extensions.Options;
using SOPHIA_MVC.Extensions;
using SOPHIA_MVC.IServices;
using SOPHIA_MVC.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SOPHIA_MVC.Services
{
    public class AutenticacaoService: Service, IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
             httpClient.BaseAddress = new Uri(settings.Value.AutenticacaoUrl);
            _httpClient = httpClient;
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = ObterConteudo(usuarioLogin);

            var response = await _httpClient.PostAsync("/api/autenticacao/autenticar", loginContent);

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DeserializeObjetoResponse<ResponseResult>(response)
                };
            }

            return await DeserializeObjetoResponse<UsuarioRespostaLogin>(response);
        }

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = ObterConteudo(usuarioRegistro);

            var response = await _httpClient.PostAsync("/api/autenticacao/nova-conta", registroContent);

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DeserializeObjetoResponse<ResponseResult>(response)
                };
            }

            return await DeserializeObjetoResponse<UsuarioRespostaLogin>(response);
        }
    }
}
