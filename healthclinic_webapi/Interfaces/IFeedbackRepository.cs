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
        /// <param name="idConsulta">ID da consulta que esse feedback esta ligado que será deletado</param>
        void Deletar(Guid idConsulta);

        /// <summary>
        /// Método para atualizar um feedback nulo
        /// </summary>
        /// <param name="idConsulta">ID da consulta daquele feedback</param>
        /// <param name="feedback">Comentario do paciente sobre a consulta</param>
        void Atualizar (Guid idConsulta, string feedback);

        /// <summary>
        /// Método para buscar um feedback pelo seu ID
        /// </summary>
        /// <param name="idConsulta">ID da consulta que esse feedback esta ligado que será buscado</param>
        /// <returns>Retorna o objeto encontrado</returns>
        Feedback BuscarPorIdConsulta(Guid idConsulta);
    }
}
