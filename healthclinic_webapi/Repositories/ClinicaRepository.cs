using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;

namespace healthclinic_webapi.Repositories
{
    /// <summary>
    /// Repository que herda os métodos da interface IClinicaRepository
    /// </summary>
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly ClinicContext _clinicContext;

        /// <summary>
        /// Construtor que instancia o objeto da context
        /// </summary>
        public ClinicaRepository()
        {
            _clinicContext = new ClinicContext();
        }

        /// <summary>
        /// Método que cadastra uma nova clinica
        /// </summary>
        /// <param name="clinica">Objeto que será cadastrado</param>
        public void Cadastrar(Clinica clinica)
        {
            try
            {
                clinica.Id = Guid.NewGuid();

                _clinicContext.Clinica.Add(clinica);
                
                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
