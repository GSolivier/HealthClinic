using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    public interface IProntuarioRepository
    {
        void Cadastrar(Prontuario prontuario);

        List<Prontuario> Listar();

        void Atualizar(Guid id, Prontuario prontuario);

        void Deletar(Guid id);

        Prontuario BuscarPorId(Guid id);
    }
}
