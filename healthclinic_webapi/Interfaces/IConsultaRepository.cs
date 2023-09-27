using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta consulta);

        List<Consulta> Listar();

        List<Consulta> ListarConsultaMedico(Guid idMedico);

        List<Consulta> ListarConsultaUsuario(Guid idUsuario);

        void Atualizar(Guid id, Consulta consulta);

        void Deletar(Guid id);

        Consulta BuscarPorId(Guid id);
    }
}
