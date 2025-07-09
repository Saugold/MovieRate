using Microsoft.AspNetCore.Mvc;
using MovieRateAPI.Services;

namespace MovieRateAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmesController : Controller
    {
        private readonly ITmdbService _tmdbService;
        public FilmesController(ITmdbService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> Buscar([FromQuery] string titulo)
        {
            var filmes = await _tmdbService.BuscarFilmesAsync(titulo);
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detalhes(int id)
        {
            var detalhes = await _tmdbService.BuscarDetalhesAsync(id);
            if (detalhes == null) return NotFound();
            return Ok(detalhes);
        }
    }
}
