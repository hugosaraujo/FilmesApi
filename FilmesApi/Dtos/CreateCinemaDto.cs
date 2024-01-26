using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Dtos;

public record CreateCinemaDto
{
    [Required(ErrorMessage = "O campo nome é obrigatório")]
    public string Nome { get; set; }
}
