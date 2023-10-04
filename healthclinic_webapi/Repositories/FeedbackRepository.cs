using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;

namespace healthclinic_webapi.Repositories
{
    /// <summary>
    /// Repository que herda os métodos da interface IFeedbackRepository
    /// </summary>
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ClinicContext _clinicContext;

        /// <summary>
        /// Construtor que instancia o objeto da context
        /// </summary>
        public FeedbackRepository()
        {
            _clinicContext = new ClinicContext();
        }

        /// <summary>
        /// Cadastra um novo Feedback
        /// </summary>
        /// <param name="feedback">objeto com os atributos a serem cadastrados</param>
        public void Cadastrar(Feedback feedback)
        {
            try
            {
                _clinicContext.Feedback.Add(feedback);

                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para deletar um FeedBack
        /// </summary>
        /// <param name="idConsulta">ID da consulta que esse feedback esta ligado que será deletado</param>
        public void Deletar(Guid idConsulta)
        {
            try
            {
                Feedback feedbackBuscado = BuscarPorIdConsulta(idConsulta);

                _clinicContext.Feedback.Remove(feedbackBuscado);

                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para buscar um feedback pelo seu ID
        /// </summary>
        /// <param name="idConsulta">ID da consulta que esse feedback esta ligado que será buscado</param>
        /// <returns>Retorna o objeto encontrado</returns>
        public Feedback BuscarPorIdConsulta(Guid idConsulta)
        {
            try
            {
                Feedback feedbackBuscado = _clinicContext.Feedback.FirstOrDefault(fb => fb.IdConsulta == idConsulta)!;

                if (feedbackBuscado == null)
                {
                    throw new Exception("O feedback não existe");
                }

                return feedbackBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para atualizar um feedback nulo
        /// </summary>
        /// <param name="idConsulta">ID da consulta daquele feedback</param>
        /// <param name="feedback">Comentario do paciente sobre a consulta</param>
        public void Atualizar(Guid idConsulta, string feedback)
        {
            try
            {
                Feedback feedbackEncontrado = BuscarPorIdConsulta(idConsulta);

                if (feedbackEncontrado.Descricao != null)
                {
                    throw new Exception("O feedback ja foi enviado e não pode ser alterado");
                }

                feedbackEncontrado.Descricao = feedback;

                _clinicContext.Feedback.Update(feedbackEncontrado);

                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
