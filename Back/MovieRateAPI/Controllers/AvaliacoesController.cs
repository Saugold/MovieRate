using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRateAPI.DTO.Filme;
using MovieRateAPI.DTO.UsuarioFilme;
using MovieRateAPI.Models;
using MovieRateAPI.Services;
using MovieRateAPI.Services.Avaliacao;
using MovieRateAPI.Services.Usuarios;

namespace MovieRateAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvaliacoesController : Controller
    {
        private readonly IUsuarioFilmeService _avaliacaoService;
        public AvaliacoesController(IUsuarioFilmeService avaliacaoService)
        {
            _avaliacaoService = avaliacaoService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CriarAvaliacao([FromBody] UsuarioFilmeDto dto)
        {
            int usuarioId = int.Parse(User.Identity!.Name!);
            if(await _avaliacaoService.GetByIdAsync(usuarioId, dto.FilmeId) != null){
                return BadRequest(new { message = "Filme já foi avaliado!" });
            }
            var avaliacao = new UsuarioFilme
            {
                UsuarioId = usuarioId,
                FilmeId = dto.FilmeId,
                Nota = dto.Nota,
                Opiniao = dto.Opiniao,
                recomendado = dto.Recomendado
            };
            await _avaliacaoService.AddAsync(avaliacao);
            return Ok(new { message = "Avaliação criada com sucesso!" });
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> AvaliacoesDoUsuario(int usuarioId)
        {
            var avaliacoes = await _avaliacaoService.GetAllByUsuarioAsync(usuarioId);
            var dtos = avaliacoes.Select(uf => new UsuarioFilmeDetalheDto
            {
                FilmeId = uf.FilmeId,
                Nota = uf.Nota,
                Opiniao = uf.Opiniao,
                Recomendado = uf.recomendado,
                Filme = new FilmeDto
                {
                    Id = uf.Filme.Id,
                    Titulo = uf.Filme.Titulo,
                    Descricao = uf.Filme.Descricao,
                    Genero = uf.Filme.Genero,
                    PosterUrl = uf.Filme.PosterUrl,
                    Duracao = uf.Filme.Duracao,
                    DataLancamento = uf.Filme.DataLancamento,
                    ApiId = uf.Filme.ApiId
                }
            }).ToList();
            return Ok(dtos);
        }

        [HttpGet("{usuarioId}/{filmeId}")]
        public async Task<IActionResult> GetById(int usuarioId, int filmeId)
        {
            var avaliacao = await _avaliacaoService.GetByIdAsync(usuarioId, filmeId);
            if (avaliacao == null)
                return NotFound();
            return Ok(avaliacao);
        }

        [HttpPut("{usuarioId}/{filmeId}")]
        [Authorize]
        public async Task<IActionResult> AtualizarAvaliacao(int usuarioId,int filmeId, [FromBody] UsuarioFilmeDto dto)
        {
            var avaliacao = await _avaliacaoService.GetByIdAsync(usuarioId, filmeId);
            if (avaliacao == null)
                return NotFound();


            avaliacao.Nota = dto.Nota;
            avaliacao.Opiniao = dto.Opiniao;
            avaliacao.recomendado = dto.Recomendado;

            await _avaliacaoService.UpdateAsync(avaliacao);
            return Ok(new { message = "Avaliação atualizada!" });
        }

        [HttpDelete("{usuarioId}/{filmeId}")]
        [Authorize]
        public async Task<IActionResult> RemoverAvaliacao(int usuarioId, int filmeId)
        {
            var avaliacao = await _avaliacaoService.GetByIdAsync(usuarioId, filmeId);
            if (avaliacao == null)
                return NotFound();

            await _avaliacaoService.DeleteAsync(usuarioId, filmeId);
            return Ok(new { message = "Avaliação removida!" });
        }

    }
}
