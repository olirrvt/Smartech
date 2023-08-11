using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartecAPI.Models;
using System.Net.Http;
using System.Text.Json;

namespace SmartecAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        [Route("Produtos")]
        [HttpGet]
        public async Task<IActionResult> GetProdutosAsync(
            [FromServices] SmartecContext smartecContext )
        {
            var produtos = await smartecContext
                .Produtos
                .AsNoTracking()
                .ToListAsync();

            return produtos == null ? NotFound() : Ok(produtos);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdProdutos(
            [FromServices] SmartecContext smartecContext,
            [FromRoute] int id)
        {
            var produto = await smartecContext
                .Produtos
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            return produto == null ? NotFound() : Ok(produto);
        
        }

        [HttpPost]
        [Route("Inserir")]
        public async Task<IActionResult> PostAsyncProdutos(
            [FromServices] SmartecContext smartecContext,
            [FromBody] Produto produto )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await smartecContext.Produtos.AddAsync(produto);
                await smartecContext.SaveChangesAsync();
                return Created($"api/Produto/Inserir/{produto.Id}", produto);
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Editar/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] SmartecContext smartecContext,
            [FromBody] Produto produto,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var prod = await smartecContext.Produtos
                .FirstOrDefaultAsync(p => p.Id == id);

            if (prod == null)
            {
                return NotFound("Produto não encontrado!");
            }

            try
            {
                if (!string.IsNullOrEmpty(produto.Categoria))
                {
                    prod.Categoria = produto.Categoria;
                }

                if (!string.IsNullOrEmpty(produto.Descricao))
                {
                    prod.Descricao = produto.Descricao;
                }

                if (!string.IsNullOrEmpty(produto.Nome))
                {
                    prod.Nome = produto.Nome;
                }

                if (produto.Preco != 0)
                {
                    prod.Preco = produto.Preco;
                }

                smartecContext.Produtos.Update(prod);
                await smartecContext.SaveChangesAsync();

                return Ok(prod);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("Deletar/{id}")]
        public async Task<IActionResult> DeleteAsync(
        [FromServices] SmartecContext smartecContext,
        [FromRoute] int id)
        {
            var prod = await smartecContext.Produtos
                .FirstOrDefaultAsync(p => p.Id == id);


            if (prod == null)
            {
                return NotFound();
            }

            try
            {
                smartecContext.Produtos.Remove(prod);
                await smartecContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
