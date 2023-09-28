using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;

namespace healthclinic_webapi.Repositories
{
    /// <summary>
    /// Repository que herda os métodos da interface IPlanoSaudeRepository
    /// </summary>
    public class PlanoSaudeRepository : IPlanoSaudeRepository
    {
        private readonly ClinicContext _clinicContext;

        /// <summary>
        /// Construtor que instancia o objeto da Context
        /// </summary>
        public PlanoSaudeRepository()
        {
            _clinicContext = new ClinicContext();
        }

        /// <summary>
        /// Método responsável por cadastrar um novo plano de saúde
        /// </summary>
        /// <param name="planoSaude">Objeto que será cadastrado</param>
        public void Cadastrar(PlanoSaude planoSaude)
        {
            try
            {
                planoSaude.Id = Guid.NewGuid();

                _clinicContext.PlanoSaude.Add(planoSaude);

                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para listar todos os planos de saúde
        /// </summary>
        /// <returns>Retorna uma lista de objetos</returns>
        public List<PlanoSaude> Listar()
        {
            try
            {
                return _clinicContext.PlanoSaude.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para atualizar um plano de saúde existente
        /// </summary>
        /// <param name="id">ID do plano de saúde que será atualizado</param>
        /// <param name="planoSaude">Objeto com os novos atributos</param>
        public void Atualizar(Guid id, PlanoSaude planoSaude)
        {
            try
            {
                PlanoSaude planoSaudeEncontrado = BuscarPorId(id);

                planoSaudeEncontrado.Titulo = planoSaude.Titulo;

                _clinicContext.PlanoSaude.Update(planoSaudeEncontrado);

                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para deletar um plano de saúde existente
        /// </summary>
        /// <param name="id">ID do plano de saúde que será deletado</param>
        public void Deletar(Guid id)
        {
            try
            {
                PlanoSaude planoSaudeEncontrado = BuscarPorId(id);

                _clinicContext.PlanoSaude.Remove(planoSaudeEncontrado);

                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para buscar um plano de saúde pelo seu ID
        /// </summary>
        /// <param name="id">ID do plano de saúde que será buscado</param>
        /// <returns>Retorna o objeto encontrado</returns>
        public PlanoSaude BuscarPorId(Guid id)
        {
            try
            {
                PlanoSaude planoSaudeEncontrado = _clinicContext.PlanoSaude.FirstOrDefault(ps => ps.Id == id)!;

                if (planoSaudeEncontrado == null)
                {
                    throw new Exception($"O plano de saúde com o id {id} não foi encontrado!");
                }

                return planoSaudeEncontrado;
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
