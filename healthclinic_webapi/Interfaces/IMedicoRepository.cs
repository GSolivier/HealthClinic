using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    /// <summary>
    /// Interface que define os métodos da entidade Medico
    /// </summary>
    public interface IMedicoRepository
    {
        /// <summary>
        /// Método para cadastrar um novo usuário do tipo Médico
        /// </summary>
        /// <param name="medico">Objeto que será cadastrado</param>
        void Cadastrar(Medico medico);

        /// <summary>
        /// Método para buscar um Médico pelo seu ID
        /// </summary>
        /// <param name="id">ID do médico que será buscado</param>
        /// <returns>Retorna o objeto encontrado</returns>
        Medico BuscarPorId(Guid id);
    }
}
