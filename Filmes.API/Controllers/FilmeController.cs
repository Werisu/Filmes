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
    public void Post([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Genero);
    }

    [HttpGet]
    public IEnumerable<Filme> GetAll([FromQuery] int skip = 0, int take = 50)
    {
        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public Filme? GetById(int id)
    {
        return filmes.FirstOrDefault(filme => filme.Id == id);
    }
}
