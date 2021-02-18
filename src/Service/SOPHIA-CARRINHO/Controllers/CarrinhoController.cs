using Microsoft.AspNetCore.Mvc;
using SOPHIA_CARRINHO.Data;
using SOPHIA_CARRINHO.Model;
using SOPHIA_WebApiCore.Usuario;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SOPHIA_WebApiCore.Controllers;

namespace SOPHIA_CARRINHO.Controllers
{
    public class CarrinhoController : MainController
    {

        private readonly IAspNetUser _user;
        private readonly CarrinhoContext _context;

        public CarrinhoController(IAspNetUser user, CarrinhoContext context)
        {   _user = user;
            _context = context;
        }
        [HttpGet("carrinho")]
        public async Task<CarrinhoCliente> ObterCarrinho()
        {
            return await ObterCarrinhoCliente() ?? new CarrinhoCliente();
        }

        [HttpPost("carrinho")]
        public async Task<IActionResult> AdicionarItemCarrinho(CarrinhoItens item)
        {
            var carrinho = await ObterCarrinhoCliente();

            if (carrinho == null)
                ManipularNovoCarrinho(item);
            else
                ManipularCarrinhoExistente(carrinho, item);

            if (!EhValida()) return CustomResponse();

            await PersistirDados();
            return CustomResponse();
        }

        [HttpPut("carrinho/{produtoId}")]
        public async Task<IActionResult> AtualizarItemCarrinho(Guid produtoId, CarrinhoItens item)
        {
            var carrinho = await ObterCarrinhoCliente();
            var itemCarrinho = await ObterItemCarrinhoValidado(produtoId, carrinho, item);
            if (itemCarrinho == null) return CustomResponse();

            carrinho.AtualizarUnidades(itemCarrinho, item.Quantidade);

            ValidarCarrinho(carrinho);
            if (!EhValida()) return CustomResponse();

            _context.CarrinhoItens.Update(itemCarrinho);
            _context.CarrinhoCliente.Update(carrinho);

            await PersistirDados();
            return CustomResponse();
        }

        [HttpDelete("carrinho/{produtoId}")]
        public async Task<IActionResult> RemoverItemCarrinho(Guid produtoId)
        {
            var carrinho = await ObterCarrinhoCliente();

            var itemCarrinho = await ObterItemCarrinhoValidado(produtoId, carrinho);
            if (itemCarrinho == null) return CustomResponse();

            ValidarCarrinho(carrinho);
            if (!EhValida()) return CustomResponse();

            carrinho.RemoverItem(itemCarrinho);

            _context.CarrinhoItens.Remove(itemCarrinho);
            _context.CarrinhoCliente.Update(carrinho);

            await PersistirDados();
            return CustomResponse();
        }



        
        private async Task<CarrinhoCliente> ObterCarrinhoCliente()
        {
          var result = await _context.CarrinhoCliente
                .Include(c => c.Itens)
                .FirstOrDefaultAsync(c => c.ClienteId == _user.ObterUserId());
          return result;
        }
        private void ManipularNovoCarrinho(CarrinhoItens item)
        {
           var carrinho = new CarrinhoCliente(_user.ObterUserId());
            carrinho.AdicionarItem(item);

            ValidarCarrinho(carrinho);
            _context.CarrinhoCliente.Add(carrinho);
        }
        private void ManipularCarrinhoExistente(CarrinhoCliente carrinho, CarrinhoItens item)
        {
            var produtoItemExistente = carrinho.CarrinhoItemExistente(item);

            carrinho.AdicionarItem(item);
            ValidarCarrinho(carrinho);

            if (produtoItemExistente)
            {
                _context.CarrinhoItens.Update(carrinho.ObterPorProdutoId(item.ProdutoId));
            }
            else
            {
                _context.CarrinhoItens.Add(item);
            }

            _context.CarrinhoCliente.Update(carrinho);
        }
        private async Task<CarrinhoItens> ObterItemCarrinhoValidado(Guid produtoId, CarrinhoCliente carrinho, CarrinhoItens item = null)
        {
            if (item != null && produtoId != item.ProdutoId)
            {
                ProcessamentoErros("O item não corresponde ao informado");
                return null;
            }

            if (carrinho == null)
            {
                ProcessamentoErros("Carrinho não encontrado");
                return null;
            }

            var itemCarrinho = await _context.CarrinhoItens
                .FirstOrDefaultAsync(i => i.CarrinhoId == carrinho.Id && i.ProdutoId == produtoId);

            if (itemCarrinho == null || !carrinho.CarrinhoItemExistente(itemCarrinho))
            {
                ProcessamentoErros("O item não está no carrinho");
                return null;
            }

            return itemCarrinho;
        }
        private async Task PersistirDados()
        {
            var result = await _context.SaveChangesAsync();
           if (result <= 0) ProcessamentoErros("Não foi possível persistir os dados no banco");
        }
        private bool ValidarCarrinho(CarrinhoCliente carrinho)
        {
            if (carrinho.EhValido()) return true;

            carrinho.ValidationResult.Errors.ToList().ForEach(e => ProcessamentoErros(e.ErrorMessage));
            return false;
        }
        
    }
}

