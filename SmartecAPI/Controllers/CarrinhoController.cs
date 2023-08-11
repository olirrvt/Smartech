using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartecAPI.Models;

namespace SmartecAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly SmartecContext _smartecContext;

        public CarrinhoController(SmartecContext smartecContext)
        {
            _smartecContext = smartecContext;
        }

        [HttpPost("CriarCarrinho")]
        public async Task<IActionResult> CriarCarrinho()
        {
            var novoCarrinho = new Carrinho();

            _smartecContext.Carrinhos.Add(novoCarrinho);
            await _smartecContext.SaveChangesAsync();

            return Ok($"Carrinho criado com ID: {novoCarrinho.IdDoCarrinho}");
        }

        [HttpPost]
        [Route("AdicionarItem/{carrinhoId}")]
        public async Task<IActionResult> AdicionarItemAsync(int carrinhoId, [FromBody] ItensCarrinho item)
        {
            var carrinho = await _smartecContext.Carrinhos
                .Include(c => c.ItensCarrinhos)
                .FirstOrDefaultAsync(c => c.IdDoCarrinho == carrinhoId);

            if (carrinho == null)
            {
                return NotFound("Carrinho não encontrado.");
            }

            carrinho.ItensCarrinhos.Add(item);
            await _smartecContext.SaveChangesAsync();

            return Ok("Item adicionado ao carrinho.");
        }

        [HttpDelete("{carrinhoId}/removerItem/{itemId}")]
        public async Task<IActionResult> RemoverItemDoCarrinho(int carrinhoId, int itemId)
        {
            var carrinho = await _smartecContext
                .Carrinhos
                .Include(c => c.ItensCarrinhos)
                .FirstOrDefaultAsync(c => c.IdDoCarrinho == carrinhoId);

            if (carrinho == null)
            {
                return NotFound("Carrinho não encontrado.");
            }

            var item = carrinho
                .ItensCarrinhos
                .FirstOrDefault(i => i.Id == itemId);

            if (item == null)
            {
                return NotFound("Item não encontrado no carrinho.");
            }

            _smartecContext.ItensCarrinhos.Remove(item);
            await _smartecContext.SaveChangesAsync();

            return Ok("Item removido do carrinho.");
        }

        [HttpPut("{carrinhoId}/atualizarQuantidade/{itemId}")]
        public async Task<IActionResult> AtualizarQuantidadeDoItem(int carrinhoId, int itemId, [FromBody] int novaQuantidade)
        {
            var carrinho = await _smartecContext.Carrinhos
                .Include(c => c.ItensCarrinhos)
                .ThenInclude(i => i.IdDoProdutoNavigation)
                .FirstOrDefaultAsync(c => c.IdDoCarrinho == carrinhoId);

            if (carrinho == null)
            {
                return NotFound("Carrinho não encontrado.");
            }

            var item = carrinho.ItensCarrinhos.FirstOrDefault(i => i.Id == itemId);

            if (item == null)
            {
                return NotFound("Item não encontrado no carrinho.");
            }

            if (novaQuantidade <= 0)
            {
                return BadRequest("A nova quantidade deve ser maior que zero.");
            }

            item.Quantidade = novaQuantidade;
            await _smartecContext.SaveChangesAsync();

            return Ok("Quantidade do item atualizada no carrinho.");
        }

        [HttpGet("{carrinhoId}/verItensCarrinho")]
        public async Task<IActionResult> VerItensCarrinho(int carrinhoId)
        {
            var carrinho = await _smartecContext.Carrinhos
                .Include(c => c.ItensCarrinhos)
                .ThenInclude(i => i.IdDoProdutoNavigation)
                .FirstOrDefaultAsync(c => c.IdDoCarrinho == carrinhoId);

            if (carrinho == null)
            {
                return NotFound("Carrinho não encontrado.");
            }

            var itensCarrinho = carrinho.ItensCarrinhos.ToList();
            return Ok(itensCarrinho);
        }

    }
}
