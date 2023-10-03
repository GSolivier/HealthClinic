using healthclinic_webapi.Domains;
using Microsoft.EntityFrameworkCore;

namespace healthclinic_webapi.Contexts
{
    /// <summary>
    /// Contexto para realizar a conexão com o banco de dados
    /// </summary>
    public class ClinicContext : DbContext
    {
        /// <summary>
        /// Instancia da tabela Administrador
        /// </summary>
        public DbSet<Administrador> Administrador { get; set; }

        /// <summary>
        /// Instancia da tabela Clinica
        /// </summary>
        public DbSet<Clinica> Clinica { get; set; }

        /// <summary>
        /// Instancia da tabela Consulta
        /// </summary>
        public DbSet<Consulta> Consulta { get; set; }

        /// <summary>
        /// Instancia da tabela
        /// </summary>
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<PlanoSaude> PlanoSaude { get; set; }
        public DbSet<Prontuario> Prontuario { get; set; }
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE18-S14; Database=healthclinic_DB; user id= sa; Pwd=Senai@134; TrustServerCertificate=True", x => x.UseDateOnlyTimeOnly());

            //optionsBuilder.UseSqlServer("Server=GUILHERME\\SQLEXPRESS; Database=healthclinic_DB; user id= sa; Pwd=Senai@134; TrustServerCertificate=True", x => x.UseDateOnlyTimeOnly());

            base.OnConfiguring(optionsBuilder);
        }
    }
}
