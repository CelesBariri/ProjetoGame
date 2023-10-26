using Microsoft.EntityFrameworkCore;

namespace ProjetoGame.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<Descricao> Descricao { get; set; }
    }
}
