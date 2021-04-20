using Microsoft.Extensions.Options;
using SOPHIA_BFF.Compras.Extensions;
using SOPHIA_BFF.Compras.IServices;
using System;
using System.Net.Http;

namespace SOPHIA_BFF.Compras.Services
{
    public class PagamentoService : Service, IPagamentoService
    {
        private readonly HttpClient _httpClient;

        public PagamentoService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.PagamentoUrl);
        }
    }
}
