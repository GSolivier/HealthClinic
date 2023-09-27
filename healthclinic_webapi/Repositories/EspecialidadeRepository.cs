using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;

namespace healthclinic_webapi.Repositories
{
    /// <summary>
    /// Repostirio que herda os métodos definidos na interface IEspecialidadeRepository
    /// </summary>
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly ClinicContext _clinicContext;

        /// <summary>
        /// Construtor que instancia o objeto da context
        /// </summary>
        public EspecialidadeRepository()
        {
            _clinicContext = new ClinicContext();
        }

        /// <summary>
        /// Método que cadastra uma nova especialidade
        /// </summary>
        /// <param name="especialidade">Objeto que será cadastrado</param>
        public void Cadastrar(Especialidade especialidade)
        {
            try
            {
                especialidade.Id = Guid.NewGuid();

                _clinicContext.Especialidade.Add(especialidade);

                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método que lista todas as especialidades
        /// </summary>
        /// <returns>Retorna uma lista com todos os objetos</returns>
        public List<Especialidade> Listar()
        {
            try
            {
                return _clinicContext.Especialidade.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método que atualiza uma especialidade já existente
        /// </summary>
        /// <param name="id">ID da especialidade que será atualizada</param>
        /// <param name="especialidade">Objeto com as novas informações</param>
        public void Atualizar(Guid id, Especialidade especialidade)
        {
            try
            {
                Especialidade especialidadeBuscada = BuscarPorId(id);

                especialidadeBuscada.Titulo = especialidade.Titulo;

                _clinicContext.Especialidade.Update(especialidadeBuscada);

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

        /// <summary>
        /// Método que busca uma especialidade
        /// </summary>
        /// <param name="id">ID da especialidade que será buscada</param>
        /// <returns>Retorna o objeto encontrado</returns>
        public Especialidade BuscarPorId(Guid id)
        {
            try
            {
                Especialidade especialidadeBuscada = _clinicContext.Especialidade.FirstOrDefault(tp => tp.Id == id)!;

                if (especialidadeBuscada == null)
                {
                    throw new Exception($"A especialidade com o ID {id} não foi encontrada");
                }

                return especialidadeBuscada;
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
