using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    /// <summary>
    /// Interface que define os métodos da entidade Administrador
    /// </summary>
    public interface IAdministradorRepository
    {
        /// <summary>
        /// Método que cadastrar um novo ADministrador
        /// </summary>
        /// <param name="administrador">Objeto que será cadastrado</param>
        void Cadastrar(Administrador administrador);

        /// <summary>
        /// Método para buscas um novo administrador pelo seu ID
        /// </summary>
        /// <param name="id">ID do adm que será buscado</param>
        /// <returns>retorna o objeto encontrado</returns>
        Administrador BuscarPorId(Guid id);
    }
}
