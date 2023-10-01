using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;

namespace healthclinic_webapi.Repositories
{
    /// <summary>
    /// Repository que herda os métodos da interface IPacienteRepository
    /// </summary>
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ClinicContext _clinicContext;
        private readonly IProntuarioRepository _prontuarioRepository;

        /// <summary>
        /// Construtor que Instancia os objetos
        /// </summary>
        public PacienteRepository()
        {
            _clinicContext = new ClinicContext();
            _prontuarioRepository = new ProntuarioRepository();
        }

        /// <summary>
        /// Método para cadastrar um Paciente e um prontuáro ja ligado a esse paciente
        /// </summary>
        /// <param name="paciente">Objeto do paciente que será cadastradi</param>
        public void Cadastrar(Paciente paciente)
        {
            try
            {
                _clinicContext.Paciente.Add(paciente);

                _clinicContext.SaveChanges();

                Prontuario prontuario = new Prontuario()
                {
                    Id = Guid.NewGuid(),
                    IdPaciente = paciente.Id,
                };

                _prontuarioRepository.Cadastrar(prontuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para buscar um paciente pelo seu ID
        /// </summary>
        /// <param name="id">ID do paciente que será buscada</param>
        /// <returns>retorna o objeto encontrado</returns>
        public Paciente BuscarPorId(Guid id)
        {
            try
            {
                Paciente pacienteBuscado = _clinicContext.Paciente
                    .Select(p => new Paciente
                    {
                        Id = p.Id,
                        Endereco = p.Endereco,

                        IdPlanoSaude = p.IdPlanoSaude,
                        PlanoSaude = new PlanoSaude
                        {
                            Titulo = p.PlanoSaude!.Titulo
                        },

                        IdUsuario = p.IdUsuario,
                        Usuario = new Usuario
                        {
                            Nome = p.Usuario!.Nome,
                            Email = p.Usuario.Email,
                            DataNascimento = p.Usuario.DataNascimento,
                            IdTipoUsuario = p.Usuario.IdTipoUsuario,
                            TipoUsuario = new TiposUsuario
                            {
                                Titulo = p.Usuario.TipoUsuario!.Titulo
                            }
                        }
                    }).FirstOrDefault(pa => pa.Id == id)!;

                if (pacienteBuscado == null)
                {
                    throw new Exception($"O paciente com o ID {id} não foi encontrado!");
                }

                return pacienteBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
