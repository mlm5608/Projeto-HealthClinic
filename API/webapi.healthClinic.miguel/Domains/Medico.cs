using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthClinic.miguel.Domains
{
    [Table(nameof(Medico))]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = new Guid();

        [Column(TypeName = "CHAR(12)")]
        [Required(ErrorMessage = "O CRM é necessário!")]
        public string? CRM { get; set; }

        //Ref. a tabela de Usuario
        [Required(ErrorMessage = "O Usuario é obrigatório!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }        
        
        //Ref a tabela de especialidade
        [Required(ErrorMessage = "A especialidade é obrigatório!")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }
    }
}
