using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    /// <summary>
    /// Interface que define os métodos da entidade Clinica
    /// </summary>
    public interface IClinicaRepository
    {
        /// <summary>
        /// Método que cadastra uma nova clinica
        /// </summary>
        /// <param name="clinica">Objeto que será cadastrado</param>
        void Cadastrar(Clinica clinica);
    }
}
