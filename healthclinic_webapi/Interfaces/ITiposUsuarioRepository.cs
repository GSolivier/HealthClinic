using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    /// <summary>
    /// Interface responsável por definir os métodos da entidade TiposUsuario
    /// </summary>
    public interface ITiposUsuarioRepository
    {
        /// <summary>
        /// Método para cadastrar um novo tipo de usuário
        /// </summary>
        /// <param name="tiposUsuario">Objeto com os novos atributos a serem cadastrados</param>
        void Cadastrar(TiposUsuario tiposUsuario);

        /// <summary>
        /// Método que lista todos os tipos de usuários
        /// </summary>
        /// <returns>Retorna uma lista com todos os objetos da tabela</returns>
        List<TiposUsuario> Listar();

        /// <summary>
        /// Método para atualizar um tipo de usuário existente
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será atualizado</param>
        /// <param name="tiposUsuario">objeto com os novos atributos que vão sobrepor os antigos</param>
        void Atualizar(Guid id, TiposUsuario tiposUsuario);

        /// <summary>
        /// Método para deletar um tipo de usuário
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será deletado</param>
        void Deletar(Guid id);

        /// <summary>
        /// Método para buscar um objeto TiposUsuario pelo seu ID
        /// </summary>
        /// <param name="id">ID do objeto que será buscado</param>
        /// <returns>Retorna o objeto encontrado</returns>
        TiposUsuario BuscarPorId(Guid id);
    }
}
