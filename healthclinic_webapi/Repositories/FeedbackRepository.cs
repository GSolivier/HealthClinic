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

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public Feedback BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }


    }
}
