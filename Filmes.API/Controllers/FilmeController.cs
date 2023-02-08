using Filmes.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.API.Controllers;
[ApiController]
[Route("Filme")]
public class FilmeController : ControllerBase
{

    private static List<Filme> filmes = new List<Filme>();

    [HttpPost]
    public void Post([FromBody] Filme filme)
    {
        filmes.Add(filme);
        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Genero);
    }
}
