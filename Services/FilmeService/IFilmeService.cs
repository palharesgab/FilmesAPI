namespace FilmesAPI.Services.FilmeService
{
    public interface IFilmeService
    {
        Task<List<Filme>> RetornaListaFilmes();
        Task<Filme?> RetornaFilme(int id);
        Task<List<Filme>> AdicionaFilme(Filme filme);
        Task<List<Filme>?> AlteraFilme(int id, Filme request);
        Task<List<Filme>?> DeletaFilme(int id);
    }
}
