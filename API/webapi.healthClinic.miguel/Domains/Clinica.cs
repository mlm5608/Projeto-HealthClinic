using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthClinic.miguel.Domains
{
    [Table(nameof(Clinica))]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; } = new Guid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome da clinica é necessário!")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(500)")]
        [Required(ErrorMessage = "O Endereço da clinica é nessário!")]
        public string? Endereco { get; set; }

        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "O CNPJ da clinica é nessário!")]
        [StringLength(14)]
        public string? CNPJ { get; set; }
    }
}
