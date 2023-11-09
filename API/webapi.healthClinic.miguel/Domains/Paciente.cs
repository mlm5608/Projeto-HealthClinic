using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.healthClinic.miguel.Domains
{
    [Table(nameof(Paciente))]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = new Guid();

        [Column(TypeName = "CHAR(12)")]
        [Required(ErrorMessage = "O CPF é necessário!")]
        public string? CPF { get; set; }

        //Ref. a tabela de Usuario
        [Required(ErrorMessage = "O Usuario é obrigatório!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
