using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;

public record ReadFilmeDto
{
    public string Titulo { get; set; }
    public int TempoDeDuracao { get; set; }
    public string Genero { get; set; }
    public DateTime MomentoDaConsulta { get; set; } = DateTime.Now;
    public ICollection<ReadSessaoDto> Sessoes { get; set; }
}
