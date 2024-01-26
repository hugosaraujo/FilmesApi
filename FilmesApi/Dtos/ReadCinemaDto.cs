using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Dtos;

public record ReadCinemaDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
}
