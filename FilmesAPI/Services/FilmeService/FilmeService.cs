using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Models;
using FilmesAPI.Services.FilmeService;
using Microsoft.AspNetCore.Http.HttpResults;
using FilmesAPI.Data;

namespace FilmesAPI.Services.FilmeService
{
    public class FilmeService : IFilmeService
    {
        private readonly DataContext _context;
        public FilmeService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Filme>> RetornaListaFilmes()
        {
            var filmes = await _context.Filmes.ToListAsync();
            return filmes;
        }

        public async Task<Filme?> RetornaFilme(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if (filme is null)
                return null;

            return filme;
        }

        public async Task<List<Filme>> AdicionaFilme(Filme filme)
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();
            return await _context.Filmes.ToListAsync();
        }

        public async Task<List<Filme>?> AlteraFilme(int id, Filme request)
        {
            var filme = await _context.Filmes.FindAsync(id);

            if (filme == null)
                return null;

            filme.Titulo = request.Titulo;
            filme.Nota = request.Nota;

            await _context.SaveChangesAsync();

            return await _context.Filmes.ToListAsync();
        }

        public async Task<List<Filme>?> DeletaFilme(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);

            if (filme is null)
                return null;

            _context.Filmes.Remove(filme);

            await _context.SaveChangesAsync();

            return await _context.Filmes.ToListAsync();
        }
    }
}
