using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
  public class DataContext : DbContext
  {
   
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Locacao> Locacoes { get; set; }
  }
}