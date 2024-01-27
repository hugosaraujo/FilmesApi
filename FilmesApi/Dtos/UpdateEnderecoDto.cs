using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Dtos;

public class UpdateEnderecoDto
{
    public string Logradouro { get; set; }
    public int Numero { get; set; }
}
