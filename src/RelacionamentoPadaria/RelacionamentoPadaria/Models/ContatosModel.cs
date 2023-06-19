using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace RelacionamentoPadaria.Models
{
    [Table("Contatos")]
    public class ContatosModel
    {
        [Key]
        [Display(Name = "Código")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Column("Nome")]
        public string? Nome { get; set; }

        [Display(Name = "Telefone")]
        [Column("Telefone")]
        public string? Telefone { get; set; }

        [Display(Name = "E-mail")]
        [Column("Email")]
        public string? Email { get; set; }

        [Display(Name = "Observacao")]
        [Column("Observacao")]
        public string? Observacao { get; set; }

        [Display(Name = "Rede Sociais")]
        [Column("RedesSociais")]
        public string? RedesSociais { get; set; }

        [Display(Name = "Status")]
        [Column("Status")]
        public bool Status { get; set; } = true;

        [Display(Name = "Data Cadastro")]
        [Column("DataCadastro")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

    }
}