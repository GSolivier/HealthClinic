using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente paciente);

        Paciente BuscarPorId(Guid id);
    }
}
