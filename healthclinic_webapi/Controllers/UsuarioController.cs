using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.DTOs;
using healthclinic_webapi.Interfaces;
using healthclinic_webapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace healthclinic_webapi.Controllers
{
    /// <summary>
    /// Controlador com os endpoints da entidade Usuário
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;
        private IPacienteRepository _pacienteRepository;
        private IAdministradorRepository _administradorRepository;
        private IMedicoRepository _medicoRepository;
        private readonly ClinicContext _healthContext;

        /// <summary>
        /// Construtor que instancia os objetos
        /// </summary>
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
            _pacienteRepository = new PacienteRepository();
            _administradorRepository = new AdministradorRepository();
            _medicoRepository = new MedicoRepository();
            _healthContext = new ClinicContext();
        }

        /// <summary>
        /// Endpoint que acessa o Método Cadastrar tanto da UsuarioRepository quanto do PacienteRepository
        /// </summary>
        /// <param name="usuarioPaciente">DTO para cadastrar um usuário do tipo paciente</param>
        /// <returns></returns>
        [HttpPost("Paciente")]
        //[Authorize(Roles = "Administrador")]
        public IActionResult PostPaciente(UsuarioPacienteDTO usuarioPaciente)
        {
            try
            {
                Usuario usuario = new Usuario() 
                { 
                    Id = Guid.NewGuid(),
                    Nome = usuarioPaciente.Nome,
                    Email = usuarioPaciente.Email,
                    Senha = usuarioPaciente.Senha,
                    DataNascimento = usuarioPaciente.DataNascimento,
                    CPF = usuarioPaciente.CPF,
                    IdTipoUsuario = usuarioPaciente.IdTipoUsuario
                };

                Paciente paciente = new Paciente()
                {
                    Id = Guid.NewGuid(),
                    Endereco = usuarioPaciente.Endereco,
                    IdUsuario = usuario.Id,
                    IdPlanoSaude = usuarioPaciente.IdPlanoSaude
                };

                _usuarioRepository.Cadastrar(usuario);

                _pacienteRepository.Cadastrar(paciente);

                return StatusCode(201);
                
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Cadastrar tanto do UsuarioRepository quanto do AdministradorRepository
        /// </summary>
        /// <param name="usuarioAdm">DTO o usuário do tipo administrador</param>
        /// <returns>Retorna um StatusCode(201) - Created</returns>
        [HttpPost("Administrador")]
        //[Authorize(Roles = "Administrador")]
        public IActionResult PostAdm(UsuarioAdmDTO usuarioAdm)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Id = Guid.NewGuid(),
                    Nome = usuarioAdm.Nome,
                    Email = usuarioAdm.Email,
                    Senha = usuarioAdm.Senha,
                    DataNascimento = usuarioAdm.DataNascimento,
                    CPF = usuarioAdm.CPF,
                    IdTipoUsuario = usuarioAdm.IdTipoUsuario
                };

                Administrador administrador = new Administrador()
                {
                    Id = Guid.NewGuid(),
                    Cargo = usuarioAdm.Cargo,
                    IdUsuario = usuario.Id
                };

                _usuarioRepository.Cadastrar(usuario);

                _administradorRepository.Cadastrar(administrador);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Cadastrar tanto do UsuarioRepository quanto do MedicoRepository
        /// </summary>
        /// <param name="usuarioMedico">DTO do usuário do tipo médico</param>
        /// <returns>Retorna um StatusCode(201) - Created</returns>
        [HttpPost("Medico")]
        //[Authorize(Roles = "Administrador")]
        public IActionResult PostMedico(UsuarioMedicoDTO usuarioMedico)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Id = Guid.NewGuid(),
                    Nome = usuarioMedico.Nome,
                    Email = usuarioMedico.Email,
                    Senha = usuarioMedico.Senha,
                    DataNascimento = usuarioMedico.DataNascimento,
                    CPF = usuarioMedico.CPF,
                    IdTipoUsuario = usuarioMedico.IdTipoUsuario
                };

                Medico medico = new Medico()
                {
                    Id = Guid.NewGuid(),
                    IdClinica = usuarioMedico.IdClinica,
                    IdUsuario = usuario.Id,
                    IdEspecialidade = usuarioMedico.IdEspecialidade,
                    CRM = usuarioMedico.CRM
                };

                _usuarioRepository.Cadastrar(usuario);

                _medicoRepository.Cadastrar(medico);

                return StatusCode(201);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que busca um usuário pelo seu ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>Retorna um StatusCode(200) - Ok com o objeto encontrado</returns>
        [HttpGet("{id}")]
        //[Authorize(Roles = "Administrador")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_usuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
