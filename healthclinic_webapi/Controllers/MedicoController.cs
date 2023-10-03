using healthclinic_webapi.Interfaces;
using healthclinic_webapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace healthclinic_webapi.Controllers
{
    /// <summary>
    /// Controlador que tem os Endpoints da entidade Medico
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository;

        /// <summary>
        /// Construtor que instancia o objeto da repository
        /// </summary>
        public MedicoController()
        {
            _medicoRepository  = new MedicoRepository();
        }

        /// <summary>
        /// Endpoint que acessa o método BuscarPorId da Repository MedicoRepository
        /// </summary>
        /// <param name="id">ID do médico que sera buscado</param>
        /// <returns>Retorna um StatusCode(200) Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_medicoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
