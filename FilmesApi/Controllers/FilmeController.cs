using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController
{
    private static List<Filme> filmes = new List<Filme>();
    private static int Id = 0; 

    [HttpPost]
    public void AdicionaFilme([FromBody] Filme filme)
    {
        filme.Id = Id++;
        filmes.Add(filme);
        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.TempoDeDuracao);
    }

    [HttpGet]
    public IEnumerable<Filme> PegaFilmes([FromQuery]int skip = 0, 
        [FromQuery]int take = 30)
    {
        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public Filme? RecuperaFilme(int id)
    {
        return filmes.FirstOrDefault(filme => filme.Id == id);
    }
}
