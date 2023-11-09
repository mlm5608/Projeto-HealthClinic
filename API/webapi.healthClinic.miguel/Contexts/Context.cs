using Microsoft.EntityFrameworkCore;
using webapi.healthClinic.miguel.Domains;

namespace webapi.healthClinic.miguel.Contexts
{
    public class Context : DbContext
    {
        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuider)
        {
            optionsBuider.UseSqlServer("Server=NOTE06-S15; Database=HealthClinic_Miguel; User Id = sa; Pwd = Senai@134; TrustServerCertificate = true;", e => e.UseDateOnlyTimeOnly());
            base.OnConfiguring(optionsBuider);
        }
    }
}
