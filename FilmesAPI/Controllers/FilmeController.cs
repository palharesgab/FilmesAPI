using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Models;
using FilmesAPI.Services.FilmeService;

namespace FilmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _filmeService;

        public FilmeController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Filme>>> RetornaListaFilmes()
        {
            return await _filmeService.RetornaListaFilmes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> RetornaFilme(int id)
        {
            var result = await _filmeService.RetornaFilme(id);
            if (result is null)
                return NotFound("Filme nao encontrado!");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Filme>>> AdicionaFilme(Filme filme)
        {
            var result = await _filmeService.AdicionaFilme(filme);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Filme>>> AlteraFilme(int id, Filme request)
        {
            var result = await _filmeService.AlteraFilme(id, request);
            if (result is null)
                return NotFound("Filme nao encontrado!");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Filme>>> DeletaFilme(int id)
        {
            var result = await _filmeService.DeletaFilme(id);
            if (result is null)
                return NotFound("Filme nao encontrado!");

            return Ok(result);
        }
    }
}