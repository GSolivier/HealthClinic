using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;

namespace healthclinic_webapi.Repositories
{
    /// <summary>
    /// Repositório que herda os métodos da interface IConsultaRepository
    /// </summary>
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly ClinicContext _clinicContext;
        private readonly IFeedbackRepository _feedbackRepository;

        /// <summary>
        /// Construtor que instancia o objeto da context
        /// </summary>
        public ConsultaRepository()
        {
            _clinicContext = new ClinicContext();
            _feedbackRepository = new FeedbackRepository();
        }

        /// <summary>
        /// Método para cadastrar uma nova consulta
        /// </summary>
        /// <param name="consulta">objeto que será cadastrado</param>
        public void Cadastrar(Consulta consulta)
        {
            try
            {
                consulta.Id = Guid.NewGuid();

                _clinicContext.Consulta.Add(consulta);

                _clinicContext.SaveChanges();

                Feedback feedback = new Feedback()
                {
                    Id = Guid.NewGuid(),
                    Visivel = true,
                    IdPaciente = consulta.IdPaciente,
                    IdConsulta = consulta.Id
                };

                _feedbackRepository.Cadastrar(feedback);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para listar todas as consultas
        /// </summary>
        /// <returns>Retorna a lista de objetos</returns>
        public List<Consulta> Listar()
        {
            try
            {
                return _clinicContext.Consulta.
                    Select(c => new Consulta
                    {
                        Id = c.Id,
                        Data = c.Data,
                        Hora = c.Hora,
                        Descricao = c.Descricao,

                        IdAdministrador = c.IdAdministrador,
                        Administrador = new Administrador
                        {
                            Cargo = c.Administrador!.Cargo,

                            IdUsuario = c.Administrador.IdUsuario,
                            Usuario = new Usuario
                            {
                                Nome = c.Administrador.Usuario!.Nome
                            }
                        },

                        IdPaciente = c.IdPaciente,
                        Paciente = new Paciente
                        {
                            Endereco = c.Paciente!.Endereco,

                            IdUsuario = c.Paciente.IdUsuario,
                            Usuario = new Usuario
                            {
                                Nome = c.Paciente.Usuario!.Nome
                            },

                            IdPlanoSaude = c.Paciente!.IdPlanoSaude,
                            PlanoSaude = new PlanoSaude
                            {
                                Titulo = c.Paciente.PlanoSaude!.Titulo
                            }
                        },

                        IdMedico = c.IdMedico,
                        Medico = new Medico
                        {
                            CRM = c.Medico!.CRM,

                            IdUsuario = c.Medico.IdUsuario,
                            Usuario = new Usuario
                            {
                                Nome = c.Medico.Usuario!.Nome
                            },

                            IdClinica = c.Medico.IdClinica,
                            Clinica = new Clinica
                            {
                                NomeFantasia = c.Medico.Clinica!.NomeFantasia,
                                Endereco = c.Medico.Clinica.Endereco
                            }
                        },
                    }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para listar as consultas ligadas a um médico
        /// </summary>
        /// <param name="idMedico">ID do médico que terá as suas consultas listadas</param>
        /// <returns>Retorna a lista de objetos</returns>
        public List<Consulta> ListarConsultaMedico(Guid idMedico)
        {
            try
            {
                return _clinicContext.Consulta.
                    Select(c => new Consulta
                    {
                        Id = c.Id,
                        Data = c.Data,
                        Hora = c.Hora,
                        Descricao = c.Descricao,

                        IdAdministrador = c.IdAdministrador,
                        Administrador = new Administrador
                        {
                            Cargo = c.Administrador!.Cargo,

                            IdUsuario = c.Administrador.IdUsuario,
                            Usuario = new Usuario
                            {
                                Nome = c.Administrador.Usuario!.Nome
                            }
                        },

                        IdPaciente = c.IdPaciente,
                        Paciente = new Paciente
                        {
                            Endereco = c.Paciente!.Endereco,

                            IdUsuario = c.Paciente.IdUsuario,
                            Usuario = new Usuario
                            {
                                Nome = c.Paciente.Usuario!.Nome
                            },

                            IdPlanoSaude = c.Paciente!.IdPlanoSaude,
                            PlanoSaude = new PlanoSaude
                            {
                                Titulo = c.Paciente.PlanoSaude!.Titulo
                            }
                        },

                        IdMedico = c.IdMedico,
                        Medico = new Medico
                        {
                            CRM = c.Medico!.CRM,

                            IdUsuario = c.Medico.IdUsuario,
                            Usuario = new Usuario
                            {
                                Nome = c.Medico.Usuario!.Nome
                            },

                            IdClinica = c.Medico.IdClinica,
                            Clinica = new Clinica
                            {
                                NomeFantasia = c.Medico.Clinica!.NomeFantasia,
                                Endereco = c.Medico.Clinica.Endereco
                            }
                        },
                    }).Where(c => c.IdMedico == idMedico).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para listar as consultas ligada a um paciente
        /// </summary>
        /// <param name="idPaciente">ID do paciente que terá as suas consultas listadas</param>
        public List<Consulta> ListarConsultaPaciente(Guid idPaciente)
        {
            return _clinicContext.Consulta.
                    Select(c => new Consulta
                    {
                        Id = c.Id,
                        Data = c.Data,
                        Hora = c.Hora,
                        Descricao = c.Descricao,

                        IdAdministrador = c.IdAdministrador,
                        Administrador = new Administrador
                        {
                            Cargo = c.Administrador!.Cargo,

                            IdUsuario = c.Administrador.IdUsuario,
                            Usuario = new Usuario
                            {
                                Nome = c.Administrador.Usuario!.Nome
                            }
                        },

                        IdPaciente = c.IdPaciente,
                        Paciente = new Paciente
                        {
                            Endereco = c.Paciente!.Endereco,

                            IdUsuario = c.Paciente.IdUsuario,
                            Usuario = new Usuario
                            {
                                Nome = c.Paciente.Usuario!.Nome
                            },

                            IdPlanoSaude = c.Paciente!.IdPlanoSaude,
                            PlanoSaude = new PlanoSaude
                            {
                                Titulo = c.Paciente.PlanoSaude!.Titulo
                            }
                        },

                        IdMedico = c.IdMedico,
                        Medico = new Medico
                        {
                            CRM = c.Medico!.CRM,

                            IdUsuario = c.Medico.IdUsuario,
                            Usuario = new Usuario
                            {
                                Nome = c.Medico.Usuario!.Nome
                            },

                            IdClinica = c.Medico.IdClinica,
                            Clinica = new Clinica
                            {
                                NomeFantasia = c.Medico.Clinica!.NomeFantasia,
                                Endereco = c.Medico.Clinica.Endereco
                            }
                        },
                    }).Where(c => c.IdPaciente == idPaciente).ToList();
          }

        /// <summary>
        /// Método para atualizar uma consulta existente
        /// </summary>
        /// <param name="id">ID da consulta que será atualizada</param>
        /// <param name="consulta">Objeto com os novos valores</param>
        public void Atualizar(Guid id, Consulta consulta)
        {
            try
            {
                Consulta consultaBuscada = BuscarPorId(id);

                consultaBuscada.Data = consulta.Data;
                consultaBuscada.Hora = consulta.Hora;

                _clinicContext.Consulta.Update(consultaBuscada);

                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para deletar uma consulta
        /// </summary>
        /// <param name="id">ID da consulta que será deletada</param>
        public void Deletar(Guid id)
        {
            try
            {
                Consulta consultaBuscada = BuscarPorId(id);

                _clinicContext.Consulta.Remove(consultaBuscada);

                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Método para buscar uma consulta por ID
        /// </summary>
        /// <param name="id">ID da consulta que será buscada</param>
        /// <returns>Retorna o objeto encontrado</returns>
        public Consulta BuscarPorId(Guid id)
        {
            try
            {
                Consulta consultaBuscada = _clinicContext.Consulta.FirstOrDefault(c => c.Id == id)!;

                if (consultaBuscada == null)
                {
                    throw new Exception("A consulta não foi encontrada");
                }

                return consultaBuscada;
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
