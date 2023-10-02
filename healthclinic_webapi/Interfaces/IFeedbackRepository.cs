using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    /// <summary>
    /// Interdace que define os métodos da entidade Feedback
    /// </summary>
    public interface IFeedbackRepository
    {
        /// <summary>
        /// Cadastra um novo Feedback
        /// </summary>
        /// <param name="feedback">objeto com os atributos a serem cadastrados</param>
        void Cadastrar(Feedback feedback);
        
        /// <summary>
        /// Método para deletar um FeedBack
        /// </summary>
        /// <param name="id">ID do feedback que será deletado</param>
        void Deletar(Guid id);

        /// <summary>
        /// Método para buscar um feedback pelo seu ID
        /// </summary>
        /// <param name="id">ID do feedback que será buscado</param>
        /// <returns>Retorna o objeto encontrado</returns>
        Feedback BuscarPorId(Guid id);
    }
}
