using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.healthClinic.miguel.Domains
{
    [Table(nameof(Especialidade))]
    public class Especialidade
    {
        [Key]
        public Guid IdEspecialidade { get; set; } = new Guid();

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O título da especialidade é necessária!")]
        public string? Titulo { get; set; }
    }
}
