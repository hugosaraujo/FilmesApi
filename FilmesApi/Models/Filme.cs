using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Filme
{
    [Required(ErrorMessage = "O Título do filme é obrigatório")]
    public string? Titulo { get; set; }
    [Required(ErrorMessage = "O Gênero do filme é obrigatório")]
    [MaxLength(50, ErrorMessage = "O Gênero não pode ter mais que 50 caracteres")]
    public string? Genero { get; set; }
    [Required]
    [Range(70, 600, ErrorMessage = "O filme deve ter uma duração entre 70 e 600 minutos")]
    public int Duracao { get; set; }
}
