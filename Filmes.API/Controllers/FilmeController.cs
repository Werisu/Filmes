using Filmes.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.API.Controllers;
[ApiController]
[Route("Filme")]
public class FilmeController : ControllerBase
{

    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpPost]
    public IActionResult Post([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        return CreatedAtAction(nameof(GetById), new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> GetAll([FromQuery] int skip = 0, int take = 50)
    {
        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var filme = filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
        {
            return NotFound();
        }
        return Ok(filme);
    }
}
