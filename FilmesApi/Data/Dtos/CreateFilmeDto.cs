using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;
public record CreateFilmeDto
{
    [Required(ErrorMessage = "O título do filme é obrigatório")]
    public string Titulo { get; set; }
    [Required]
    [Range(60, 600, ErrorMessage = "A duração do filme deve ser entre e 60 e 600")]
    public int TempoDeDuracao { get; set; }
    [Required(ErrorMessage = "O gênero do filme é obrigatório")]
    [StringLength(25, ErrorMessage = "O tamanho do gênero não pode exceder 25 caracteres")]
    public string Genero { get; set; }
}
