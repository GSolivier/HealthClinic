using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using healthclinic_webapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace healthclinic_webapi.Controllers
{
    /// <summary>
    /// Controlador com os endpoints da entidade Consulta
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository;

        /// <summary>
        /// Construtor que instancia o objeto do repository
        /// </summary>
        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Endpoint que acessa o método cadastrar da ConsultaRepository
        /// </summary>
        /// <param name="consulta">objeto que será cadastrado</param>
        /// <returns>Retorna um StatusCode(201) - Created</returns>
        [HttpPost]
        public IActionResult Post(Consulta consulta)
        {
            try
            {
                _consultaRepository.Cadastrar(consulta);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método listar da ConsultaRepository
        /// </summary>
        /// <returns>Retorna a lista de objetos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_consultaRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método ListarConsultaPaciente na ConsultaRepository
        /// </summary>
        /// <param name="idPaciente">ID do paciente que terá as suas consultas listadas</param>
        /// <returns>Retorna as consultas daquele paciente</returns>
        [HttpGet("paciente/{idPaciente}")]
        public IActionResult GetByIdPaciente(Guid idPaciente)
        {
            try
            {
               return Ok(_consultaRepository.ListarConsultaPaciente(idPaciente));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método ListarConsultaMedico na ConsultaRepository
        /// </summary>
        /// <param name="idMedico">ID do medico que terá as suas consultas listadas</param>
        /// <returns>Retorna as consultas daquele medico</returns>
        [HttpGet("medico/{idMedico}")]
        public IActionResult GetByIdMedico(Guid idMedico)
        {
            try
            {
                return Ok(_consultaRepository.ListarConsultaMedico(idMedico));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Atualizar da ConsultaRepository
        /// </summary>
        /// <param name="id">ID da consulta que será atualizada</param>
        /// <param name="consulta">Objeto com os novos valores</param>
        /// <returns>Retorna um StatusCode(200) - Ok</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Consulta consulta)
        {
            try
            {
                _consultaRepository.Atualizar(id, consulta);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Deletar do ConsultaRepository
        /// </summary>
        /// <param name="id">ID da consulta que será deletada</param>
        /// <returns>Retorna um StatusCode(200) Ok</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _consultaRepository.Deletar(id);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
