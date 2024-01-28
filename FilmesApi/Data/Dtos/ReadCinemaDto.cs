using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;

public record ReadCinemaDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ReadEnderecoDto Endereco { get; set; }
}
