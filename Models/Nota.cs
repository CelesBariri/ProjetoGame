using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoGame.Models
{
    [Table("Nota")]
    public class Nota
    {
        [Column("NotaId")]
        [Display(Name = "Cód da Nota")]
        public int Id { get; set; }

        [Column("NotaValor")]
        [Display(Name = "Valor da Nota")]
        public int NotaValor { get; set; }

    }
}
