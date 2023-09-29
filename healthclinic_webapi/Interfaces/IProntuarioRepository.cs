using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    /// <summary>
    /// Interface que define os métodos da entidade Prontuario
    /// </summary>
    public interface IProntuarioRepository
    {
        /// <summary>
        /// Método para cadastrar um novo prontuário
        /// </summary>
        /// <param name="prontuario">objeto que será cadastrado</param>
        void Cadastrar(Prontuario prontuario);

        /// <summary>
        /// Método para atualizar um prontuário
        /// </summary>
        /// <param name="id">ID do prontuario que será atualizado</param>
        /// <param name="prontuario">Objeto com os novos atributos</param>
        void Atualizar(Guid id, Prontuario prontuario);

        /// <summary>
        /// Método para buscar um prontuário pelo seu ID
        /// </summary>
        /// <param name="id">ID do prontuário que será buscado</param>
        /// <returns>Retorna o objeto encontrado</returns>
        Prontuario BuscarPorId(Guid id);

        /// <summary>
        /// Método para buscar um prontuário pelo ID do usuario ligado a ele
        /// </summary>
        /// <param name="idPaciente">ID do usuario que terá o seu prontuáro buscado</param>
        /// <returns>retorna o objeto encontrado</returns>
        Prontuario BuscarPorIdPaciente(Guid idPaciente);
    }
}
