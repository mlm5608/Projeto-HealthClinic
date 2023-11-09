using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthClinic.miguel.Domains
{
    [Table(nameof(Usuario))]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = new Guid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Email é necessário")]
        public string? Email { get; set; } 
        
        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "A Senha é necessária")]
        public string? Senha { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Nome é necessária")]
        public string? Nome { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A Data é necessária")]
        public DateTime DataDeNascimento { get; set; }

        //Ref a tabela de TipoUsuario

        [Required(ErrorMessage = "O tipo do Usuario é obrigatório!")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
