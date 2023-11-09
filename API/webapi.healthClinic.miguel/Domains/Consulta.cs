using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthClinic.miguel.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; } = new Guid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage ="O prontuário da consulta é necessário")]
        public string? Prontuario { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data da consulta é necessária")]
        public DateTime? Data { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "O horário da consulta é necessário")]
        public TimeOnly? Hora { get; set; }

        //ref a tabela de Medico
        [Required(ErrorMessage = "O Médico é obrigatório!")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }

        //Ref a tabela de pacientes
        [Required(ErrorMessage = "O Paciente é obrigatório!")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

        //Ref a tabela de Clinica
        [Required(ErrorMessage = "A clinica é obrigatória!")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }
    }
}
