using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoGame.Models
{
    [Table("Cadastro")]
    public class Cadastro
    {
        [Column("CadastroId")]
        [Display(Name = "Cód do Cadastro")]
        public int CadastroId { get; set; }

        [Column("CadastroNome")]
        [Display(Name = "Nome do Jogo")]
        public string CadastroNome { get; set; } = string.Empty;

        [Column("CadastroCategoria")]
        [Display(Name = "Categoria do Jogo")]
        public string CadastroName { get; set; } = string.Empty;


    }
}
