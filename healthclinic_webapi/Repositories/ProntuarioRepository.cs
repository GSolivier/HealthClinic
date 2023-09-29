using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;

namespace healthclinic_webapi.Repositories
{
    /// <summary>
    /// Repository que herda os métodos da interface IPronturarioRepository
    /// </summary>
    public class ProntuarioRepository : IProntuarioRepository
    {
        private readonly ClinicContext _clinicContext;
        
        /// <summary>
        /// construtor que instancia a Context
        /// </summary>
        public ProntuarioRepository()
        {
            _clinicContext = new ClinicContext();
        }


        /// <summary>
        /// Método para cadastrar um novo prontuário
        /// </summary>
        /// <param name="prontuario">objeto que será cadastrado</param>
        public void Cadastrar(Prontuario prontuario)
        {
            try
            {
                _clinicContext.Prontuario.Add(prontuario);

                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para atualizar um prontuário
        /// </summary>
        /// <param name="id">ID do paciente que tera o prontuario que será atualizado</param>
        /// <param name="prontuario">Objeto com os novos atributos</param>
        public void Atualizar(Guid id, Prontuario prontuario)
        {
            try
            {
                Prontuario prontuarioEncontrado = BuscarPorIdPaciente(id);

                prontuarioEncontrado.Descricao = prontuario.Descricao;

                _clinicContext.Prontuario.Update(prontuarioEncontrado);

                _clinicContext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para buscar um prontuário pelo seu ID
        /// </summary>
        /// <param name="id">ID do prontuário que será buscado</param>
        /// <returns>Retorna o objeto encontrado</returns>
        public Prontuario BuscarPorId(Guid id)
        {
            try
            {
                Prontuario prontuarioEncontrado = _clinicContext.Prontuario.FirstOrDefault(p => p.Id == id)!;

                if (prontuarioEncontrado == null)
                {
                    throw new Exception("O prontuário com o id {id} não foi encontrado");
                }

                return prontuarioEncontrado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para buscar um prontuário pelo ID do usuario ligado a ele
        /// </summary>
        /// <param name="idPaciente">ID do usuario que terá o seu prontuáro buscado</param>
        /// <returns>retorna o objeto encontrado</returns>
        public Prontuario BuscarPorIdPaciente(Guid idPaciente)
        {
            try
            {
                Prontuario prontuarioEncontrado = _clinicContext.Prontuario.FirstOrDefault(p => p.IdPaciente == idPaciente)!;

                if (prontuarioEncontrado == null)
                {
                    throw new Exception($"O prontuário com o id do paciente {idPaciente} não foi encontrado");
                }

                return prontuarioEncontrado;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
