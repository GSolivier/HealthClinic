using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    public interface IAdministradorRepository
    {
        void Cadastrar(Administrador administrador);

        Administrador BuscarPorId(Guid id);
    }
}
