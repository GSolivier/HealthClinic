using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;

namespace healthclinic_webapi.Repositories
{
    /// <summary>
    /// Repostirio que herda os métodos definidos na interface ITiposUsuarioRepository
    /// </summary>
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly ClinicContext _clinicContext;

        /// <summary>
        /// Construtor que instancia a classe do contexto
        /// </summary>
        public TiposUsuarioRepository()
        {
            _clinicContext = new ClinicContext();
        }

        /// <summary>
        /// Método para cadastrar um novo tipo de usuário
        /// </summary>
        /// <param name="tiposUsuario">Objeto com os novos atributos a serem cadastrados</param>
        public void Cadastrar(TiposUsuario tiposUsuario)
        {
            try
            {
                tiposUsuario.Id = Guid.NewGuid();

                _clinicContext.TiposUsuario.Add(tiposUsuario);

                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método que lista todos os tipos de usuários
        /// </summary>
        /// <returns>Retorna uma lista com todos os objetos da tabela</returns>
        public List<TiposUsuario> Listar()
        {
            try
            {
                return _clinicContext.TiposUsuario.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para atualizar um tipo de usuário existente
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será atualizado</param>
        /// <param name="tiposUsuario">objeto com os novos atributos que vão sobrepor os antigos</param>
        public void Atualizar(Guid id, TiposUsuario tiposUsuario)
        {
            try
            {
                TiposUsuario tipoUsuarioBuscado = BuscarPorId(id);
                
                tipoUsuarioBuscado.Titulo = tiposUsuario.Titulo;

                _clinicContext.TiposUsuario.Update(tipoUsuarioBuscado);

                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para deletar um tipo de usuário
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será deletado</param>
        public void Deletar(Guid id)
        {
            try
            {
                TiposUsuario tipoUsuarioBuscado = BuscarPorId(id);

                _clinicContext.TiposUsuario.Remove(tipoUsuarioBuscado); 

                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para buscar um objeto TiposUsuario pelo seu ID
        /// </summary>
        /// <param name="id">ID do objeto que será buscado</param>
        /// <returns>Retorna o objeto encontrado</returns>
        public TiposUsuario BuscarPorId(Guid id)
        {
            try
            {
                TiposUsuario tipoUsuarioBuscado = _clinicContext.TiposUsuario.FirstOrDefault(tp => tp.Id == id)!;

                if (tipoUsuarioBuscado == null)
                {
                    throw new Exception($"O tipo de usuário com o ID {id} não foi encontrado");
                }

                return tipoUsuarioBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
