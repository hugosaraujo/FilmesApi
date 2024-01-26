using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Dtos;

public record UpdateCinemaDto
{
    [Required(ErrorMessage = "O campo nome é obrigatório")]
    public string Nome { get; set; }
}
