using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    /// <summary>
    /// Interface que define os métodos da entidade Consulta
    /// </summary>
    public interface IConsultaRepository
    {
        /// <summary>
        /// Método para cadastrar uma nova consulta
        /// </summary>
        /// <param name="consulta">objeto que será cadastrado</param>
        void Cadastrar(Consulta consulta);

        /// <summary>
        /// Método para listar todas as consultas
        /// </summary>
        /// <returns>Retorna a lista de objetos</returns>
        List<Consulta> Listar();

        /// <summary>
        /// Método para listar as consultas ligadas a um médico
        /// </summary>
        /// <param name="idMedico">ID do médico que terá as suas consultas listadas</param>
        /// <returns>Retorna a lista de objetos</returns>
        List<Consulta> ListarConsultaMedico(Guid idMedico);

        /// <summary>
        /// Método para listar as consultas ligada a um paciente
        /// </summary>
        /// <param name="idPaciente">ID do paciente que terá as suas consultas listadas</param>
        /// <returns></returns>
        List<Consulta> ListarConsultaPaciente(Guid idPaciente);

        /// <summary>
        /// Método para atualizar uma consulta existente
        /// </summary>
        /// <param name="id">ID da consulta que será atualizada</param>
        /// <param name="consulta">Objeto com os novos valores</param>
        void Atualizar(Guid id, Consulta consulta);

        /// <summary>
        /// Método para deletar uma consulta
        /// </summary>
        /// <param name="id">ID da consulta que será deletada</param>
        void Deletar(Guid id);

        /// <summary>
        /// Método para buscar uma consulta por ID
        /// </summary>
        /// <param name="id">ID da consulta que será buscada</param>
        /// <returns>Retorna o objeto encontrado</returns>
        Consulta BuscarPorId(Guid id);
    }
}
