using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    /// <summary>
    /// Interface que defini os métodos da entidade Usuario
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Método para cadastrar um novo usuário
        /// </summary>
        /// <param name="usuario">Objeto que será cadastrado</param>
        void Cadastrar(Usuario usuario);

        /// <summary>
        /// Método para buscar um usuário pelo seu ID
        /// </summary>
        /// <param name="id">ID do usário que será buscado</param>
        /// <returns>Retorna o objeto encontrado</returns>
        Usuario BuscarPorId(Guid id);

        /// <summary>
        /// Método para buscar um usuário pelo seu Email e Senha
        /// </summary>
        /// <param name="email">Email do usuário que será buscado</param>
        /// <param name="senha">Senha do usuário que será buscada</param>
        /// <returns>Retorna o objeto encontrado</returns>
        Usuario BuscarPorEmailESenha(string email, string senha);
    }
}
