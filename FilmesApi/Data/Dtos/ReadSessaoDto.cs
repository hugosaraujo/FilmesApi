namespace FilmesApi.Data.Dtos;

public record ReadSessaoDto
{
    public int FilmeId { get; set; }
    public int CinemaId { get; set; }
}
