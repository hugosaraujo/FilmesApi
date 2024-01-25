using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int Id = 0; 

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] Filme filme)
    {
        filme.Id = Id++;
        filmes.Add(filme);
        return CreatedAtAction(nameof(RecuperaFilmePorId),
                       new { Id = filme.Id }, 
                       filme);
    }

    [HttpGet]
    public IEnumerable<Filme> PegaFilmes([FromQuery]int skip = 0, 
        [FromQuery]int take = 30)
    {
        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        var filme = filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        return Ok(filme);
        
    }
}
