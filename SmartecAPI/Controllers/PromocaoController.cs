using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartecAPI.Models;

namespace SmartecAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocaoController : ControllerBase
    {
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> getByIdPromo(
            [FromServices] SmartecContext smartecContext,
            [FromRoute] int id )
        {
            var promocao = await smartecContext
                .Promocaos
                .Include(p => p.Produtos)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.IdDaPromocao == id);

            return promocao == null ? NotFound() : Ok(promocao);
        }

        [HttpGet]
        [Route("Promos")]
        public async Task<IActionResult> getAllAsync(
            [FromServices] SmartecContext smartecContext)
        {
            var promocoes = await smartecContext
                .Promocaos
                .AsNoTracking()
                .ToListAsync();

            return promocoes == null ? NotFound() : Ok(promocoes);
        }


        [HttpPost]
        [Route("Cadastrar")]
        public async Task<IActionResult> postPromocaoAsync(
            [FromServices] SmartecContext smartecContext,
            [FromBody] Promocao promocao )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await smartecContext.Promocaos.AddAsync(promocao);
                await smartecContext.SaveChangesAsync();
                return Created($"api/Promocao/Cadastrar", promocao);
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
            var promo = await smartecContext.Promocaos
                .FirstOrDefaultAsync(p => p.IdDaPromocao == id);


            if (promo == null)
            {
                return NotFound();
            }

            try
            {
                smartecContext.Promocaos.Remove(promo);
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
