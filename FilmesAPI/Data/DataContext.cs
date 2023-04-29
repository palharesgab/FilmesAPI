global using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=filmedb;Trusted_Connection=true;TrustServerCertificate=true");
        }

        public DbSet<Filme> Filmes { get; set; }
    }
}