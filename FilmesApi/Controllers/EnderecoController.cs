using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Data;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public EnderecoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { id = endereco.Id }, endereco);
    }

    [HttpGet]
    public IEnumerable<ReadEnderecoDto> RecuperaEnderecos()
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaEnderecoPorId(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
        if (endereco is null) return NotFound();
        var enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
        return Ok(enderecoDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
    {
        var endereco = _context.Cinemas.FirstOrDefault(e => e.Id == id);
        if (endereco is null) return NotFound();
        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult ApagaEndereco(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
        if (endereco is null) return NotFound();
        _context.Enderecos.Remove(endereco);
        _context.SaveChanges();
        return NoContent();
    }
}
