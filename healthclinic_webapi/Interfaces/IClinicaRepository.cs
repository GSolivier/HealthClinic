using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica clinica);
    }
}
