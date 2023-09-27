using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico Medico);

        Medico BuscarPorId(Guid id);
    }
}
