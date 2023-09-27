using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    public interface IFeedbackRepository
    {
        void Cadastrar(Feedback feedback);

        List<Feedback> Listar();

        void Atualizar(Guid id, Feedback feedback);

        void Deletar(Guid id);

        Feedback BuscarPorId(Guid id);
    }
}
