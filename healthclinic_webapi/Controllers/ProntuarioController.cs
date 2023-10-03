using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using healthclinic_webapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace healthclinic_webapi.Controllers
{
    /// <summary>
    /// Controlador que possue os endpoints da Entidade Prontuario
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProntuarioController : ControllerBase
    {
        private IProntuarioRepository _prontuarioRepository;

        /// <summary>
        /// Controlador que instancia a classe do repository
        /// </summary>
        public ProntuarioController()
        {
            _prontuarioRepository = new ProntuarioRepository();
        }

        /// <summary>
        /// Endpoint que acessa o método Atualizar da ProntuarioRepository
        /// </summary>
        /// <param name="idPaciente">ID do paciente que terá o seu prontuário atualizado</param>
        /// <param name="prontuario">Objeto com os novos valores</param>
        /// <returns>Retorna um StatusCode(200) - Ok</returns>
        [HttpPut("{idPaciente}")]
        public IActionResult Put(Guid idPaciente, Prontuario prontuario)
        {
            try
            {
                _prontuarioRepository.Atualizar(idPaciente, prontuario);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
