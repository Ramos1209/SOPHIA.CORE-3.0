using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SOPHIA_MVC.Extensions;
using SOPHIA_MVC.IServices;
using SOPHIA_MVC.Models;

namespace SOPHIA_MVC.Services
{
    public class CatalogoService : Service, ICatalogoService
    {
        private readonly HttpClient _httpClient;
        public CatalogoService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.CatalogoUrl);
            _httpClient = httpClient;
        }
        public async Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"catalogo/produtos/{id}");

            TratarErrosResponse(response);
            return await DeserializeObjetoResponse<ProdutoViewModel>(response);


        }
        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            var response = await _httpClient.GetAsync("/catalogo/produtos/");

            TratarErrosResponse(response);
            return await DeserializeObjetoResponse<IEnumerable<ProdutoViewModel>>(response);
        }
    }
}
