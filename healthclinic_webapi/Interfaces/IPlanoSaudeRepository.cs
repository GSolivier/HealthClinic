using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    public interface IPlanoSaudeRepository
    {
        void Cadastrar(PlanoSaude planoSaude);

        List<PlanoSaude> Listar();

        void Atualizar(Guid id, PlanoSaude planoSaude);

        void Deletar(Guid id);

        PlanoSaude BuscarPorId(Guid id);
    }
}

