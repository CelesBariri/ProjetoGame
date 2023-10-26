using Microsoft.EntityFrameworkCore;
using ProjetoGame.Models;

namespace ProjetoGame.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        } 
        public DbSet<Nota> Nota { get; set; }
        public DbSet<Descricao> Descricao { get; set; }
    }
}
