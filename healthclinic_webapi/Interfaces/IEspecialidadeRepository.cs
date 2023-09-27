using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    /// <summary>
    /// Interface que define os métodos da entidade Especialidade
    /// </summary>
    public interface IEspecialidadeRepository
    {
        /// <summary>
        /// Método que cadastra uma nova especialidade
        /// </summary>
        /// <param name="especialidade">Objeto que será cadastrado</param>
        void Cadastrar(Especialidade especialidade);

        /// <summary>
        /// Método que lista todas as especialidades
        /// </summary>
        /// <returns>Retorna uma lista com todos os objetos</returns>
        List<Especialidade> Listar();

        /// <summary>
        /// Método que atualiza uma especialidade já existente
        /// </summary>
        /// <param name="id">ID da especialidade que será atualizada</param>
        /// <param name="especialidade">Objeto com as novas informações</param>
        void Atualizar(Guid id, Especialidade especialidade);

        /// <summary>
        /// Método que deleta uma especialidade
        /// </summary>
        /// <param name="id">ID da especialidade que será deletada</param>
        void Deletar(Guid id);

        /// <summary>
        /// Método que busca uma especialidade
        /// </summary>
        /// <param name="id">ID da especialidade que será buscada</param>
        /// <returns>Retorna o objeto encontrado</returns>
        Especialidade BuscarPorId(Guid id);
    }
}

