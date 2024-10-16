using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para a criação de um filme</param>
    /// <returns>IACtionResult</returns>
    /// <response code="201">Caso a ação obtenha êxito</response>
    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id }, filme);
    }

    /// <summary>
    /// Retorna uma lista de Filmes
    /// </summary>
    /// <param name="skip">Informa quantos itens devem ser pulados no retorno</param>
    /// <param name="take">Informa o intervalo de filmes que deve ser retornado</param>
    /// <param name="nomeCinema">Pode receber um parâmetro nome do cinema para filtra filme por cinema</param>
    /// <returns>IEnumerable</returns>
    /// <response code="200">Obtendo êxito na resposta</response>
    [HttpGet]
    public IEnumerable<ReadFilmeDto> RecuperaFilmes(
        [FromQuery]int skip = 0, 
        [FromQuery]int take = 10,
        [FromQuery]string? nomeCinema = null)
    {
        if (nomeCinema is null )
        {
            return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take).ToList());
        }

        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes
            .Skip(skip)
            .Take(take)
            .Where(filme => filme.Sessoes.Any(sessao => sessao.Cinema.Nome.Equals(nomeCinema)))
            .ToList());
    }

    /// <summary>
    /// Retorna um filme a partir do valor do Id
    /// </summary>
    /// <param name="id">Valor de um Id para fazer a busca no banco de dados</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a ação obtenha êxito</response>
    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme is null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);  
    }
    
    /// <summary>
    /// Atualiza o objeto inteiro de um filme
    /// </summary>
    /// <param name="id">Valor de Id para conseguir buscar um filme no banco de dados</param>
    /// <param name="filmeDto">Objeto com os campos necessário para fazer a atualização</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso obtenha êxito</response>
    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody]UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id); 
        if (filme is null) return NotFound();
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Atualiza um parâmetro de um objeto filme
    /// </summary>
    /// <param name="id">Id para a busca do filme no banco de dados</param>
    /// <param name="patch">Corpo do parâmetro a ser atualizado no banco de dados</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso obtenha resposta positiva</response>
    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmePorParte(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme is null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);
        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar)) return ValidationProblem(ModelState);

        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Apaga um filme do banco de dados
    /// </summary>
    /// <param name="id">Id para buscar um filme à ser apagado</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso obtenha êxito</response>
    [HttpDelete("{id}")]
    public IActionResult ApagaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme is null) return NotFound();
        _context.Filmes.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}