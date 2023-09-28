using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    /// <summary>
    /// Interface responsável por definir os métodos da entidade PlanoSaude
    /// </summary>
    public interface IPlanoSaudeRepository
    {
        /// <summary>
        /// Método responsável por cadastrar um novo plano de saúde
        /// </summary>
        /// <param name="planoSaude">Objeto que será cadastrado</param>
        void Cadastrar(PlanoSaude planoSaude);

        /// <summary>
        /// Método para listar todos os planos de saúde
        /// </summary>
        /// <returns>Retorna uma lista de objetos</returns>
        List<PlanoSaude> Listar();

        /// <summary>
        /// Método para atualizar um plano de saúde existente
        /// </summary>
        /// <param name="id">ID do plano de saúde que será atualizado</param>
        /// <param name="planoSaude">Objeto com os novos atributos</param>
        void Atualizar(Guid id, PlanoSaude planoSaude);

        /// <summary>
        /// Método para deletar um plano de saúde existente
        /// </summary>
        /// <param name="id">ID do plano de saúde que será deletado</param>
        void Deletar(Guid id);

        /// <summary>
        /// Método para buscar um plano de saúde pelo seu ID
        /// </summary>
        /// <param name="id">ID do plano de saúde que será buscado</param>
        /// <returns>Retorna o objeto encontrado</returns>
        PlanoSaude BuscarPorId(Guid id);
    }
}

