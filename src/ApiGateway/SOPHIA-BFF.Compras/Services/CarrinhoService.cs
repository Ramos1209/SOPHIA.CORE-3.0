using Microsoft.Extensions.Options;
using SOPHIA_BFF.Compras.Extensions;
using SOPHIA_BFF.Compras.IServices;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using SOPHIA_BFF.Compras.Models;
using SOPHIA_Core.Comunication;

namespace SOPHIA_BFF.Compras.Services
{
    public class CarrinhoService : Service, ICarrinhoService
    {
        private readonly HttpClient _httpClient;

        public CarrinhoService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CarrinhoUrl);
        }

        public async Task<CarrinhoDto> ObterCarrinho()
        {
            var response = await _httpClient.GetAsync("/carrinho/");
            TratarErrosResponse(response);
            return await DeserializarObjetoResponse<CarrinhoDto>(response);
        }

        public async Task<ResponseResult> AdicionarItenCarrinho(ItemCarrinhoDto produto)
        {
            var itemContent = ObterConteudo(produto);
            var response = await _httpClient.PostAsync("/carrinho/", itemContent);
            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);
            return RetornoOk();
        }

        public async Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoDto carrinho)
        {
            var itemContent = ObterConteudo(carrinho);
            var response = await _httpClient.PostAsync($"/carrinho/{carrinho.ProdutoId}", itemContent);
            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);
            return RetornoOk();
        }

        public async Task<ResponseResult> RemoverItemCarrinho(Guid produtoId)
        {
           
            var response = await _httpClient.DeleteAsync($"/carrinho/{produtoId}");
            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);
            return RetornoOk();
        }

        public async Task<ResponseResult> AplicarVoucherCarrinho(VoucherDTO voucher)
        {
            var itemContent = ObterConteudo(voucher);
            var response = await _httpClient.PostAsync("/carrinho/aplicar-voucher/", itemContent);
            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);
            return RetornoOk();
        }
    }
}
