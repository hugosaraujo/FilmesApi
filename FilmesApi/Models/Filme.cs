using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace FilmesApi.Models;

public class Filme
{
    [Required(ErrorMessage = "O título do filme é obrigatório")]
    public string Titulo { get; set; }
    [Required]
    [Range(60, 600, ErrorMessage = "A duração do filme deve ser entre e 60 e 600")]
    public int TempoDeDuracao { get; set; }
    [Required(ErrorMessage = "O gênero do filme é obrigatório")]
    [MaxLength(25, ErrorMessage = "O tamanho do gênero não pode exceder 25 caracteres")]
    public string Genero { get; set; }
}
