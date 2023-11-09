using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace webapi.healthClinic.miguel.Domains
{
    [Table(nameof(TipoUsuario))]
    public class TipoUsuario
    {
        [Key]
        public Guid IdTipoUsuario { get; set; } = new Guid();

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O título do tipo é necessário!")]
        public string? Titulo { get; set; }
    }
}
