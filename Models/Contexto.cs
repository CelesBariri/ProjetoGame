using Microsoft.EntityFrameworkCore;
using ProjetoGame.Models;

namespace ProjetoGame.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        } 
        public DbSet<Cadastro> Cadastro { get; set; }
    }
}
