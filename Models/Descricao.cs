using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoGame.Models
{
    [Table("Descricao")]
    public class Descricao
    {
        [Column("DescricaoId")]
        [Display(Name = "Cód Da Descrição")]
        public int DescricaoId { get; set; }

        [ForeignKey("NotaId")]
        public int NotaId { get; set; }
        public Nota? Nota { get; set; }

        [ForeignKey("CadastroId")]
        public int CadastroId { get; set; }
        public Cadastro? Cadastro { get; set; }

        [Column("DescricaoJogo")]
        [Display(Name = "Descrição do Jogo")]
        public string DescricaoJogo { get; set; } = string.Empty;

    }
}
