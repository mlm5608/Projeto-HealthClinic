using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthClinic.miguel.Domains
{
    [Table(nameof(Comentario))]
    public class Comentario
    {
        [Key]
        public Guid IdComentario { get; set; } = new Guid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O titulo do comentario é necessário")]
        public string? Titulo { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição do comentario é necessária")]
        public string? Descrição { get; set; }

        [Column(TypeName = "BIT")]
        public bool Exibe { get; set; }

        //Ref a tabela de Consulta
        [Required(ErrorMessage = "A consulta é obrigatória!")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }
    }
}
