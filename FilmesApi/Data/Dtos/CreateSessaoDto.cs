namespace FilmesApi.Data.Dtos;

public record CreateSessaoDto
{
    public int FilmeId { get; set; }
    public int CinemaId { get; set; }
}
