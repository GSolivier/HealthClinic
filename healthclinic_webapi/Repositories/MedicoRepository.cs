using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using System.Runtime.Intrinsics.Arm;

namespace healthclinic_webapi.Repositories
{
    /// <summary>
    /// Repository que armazena os métodos
    /// </summary>
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ClinicContext _clinicContext;

        /// <summary>
        /// Construtor que instancia a Context
        /// </summary>
        public MedicoRepository()
        {
            _clinicContext = new ClinicContext();
        }

        /// <summary>
        /// Método para cadastrar um novo usuário do tipo Médico
        /// </summary>
        /// <param name="medico">Objeto que será cadastrado</param>
        public void Cadastrar(Medico medico)
        {
            try
            {
                _clinicContext.Medico.Add(medico);

                _clinicContext.SaveChanges();
            }

            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para buscar um Médico pelo seu ID
        /// </summary>
        /// <param name="id">ID do médico que será buscado</param>
        /// <returns>Retorna o objeto encontrado</returns>
        public Medico BuscarPorId(Guid id)
        {
            try
            {
                Medico medicoBuscado = _clinicContext.Medico.
                    Select( med => new Medico
                    {
                        Id = med.Id,
                        CRM = med.CRM,
                        IdClinica = med.IdClinica,
                        Clinica = new Clinica
                        {
                            HoraInicio = med.Clinica!.HoraInicio,
                            HoraFinal = med.Clinica!.HoraFinal,
                            Endereco = med.Clinica!.Endereco,
                            NomeFantasia = med.Clinica!.NomeFantasia
                        },

                        IdUsuario = med.IdUsuario,
                        Usuario = new Usuario
                        {
                            Nome = med.Usuario!.Nome,
                            Email = med.Usuario!.Email,
                            IdTipoUsuario = med.Usuario!.IdTipoUsuario
                        },

                        IdEspecialidade = med.IdEspecialidade,
                        Especialidade = med.Especialidade
                    }

                    ).FirstOrDefault(med => med.Id == id)!;

                if (medicoBuscado == null)
                {
                    throw new Exception($"O médico com o ID {id} não foi encontrado");
                }

                return medicoBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
