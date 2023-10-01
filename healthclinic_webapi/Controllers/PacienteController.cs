using healthclinic_webapi.Interfaces;
using healthclinic_webapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace healthclinic_webapi.Controllers
{
    /// <summary>
    /// Controlador que armazena os Ednpoiints da entidade Paciente
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository;

        /// <summary>
        /// Construtor que instancia a Repository
        /// </summary>
        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// Endpoint que acessa o método BuscarPorId no PacienteRepository
        /// </summary>
        /// <param name="id">ID do paciente que será buscado</param>
        /// <returns>Retorna o objeto encotnrado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) 
        {
            try
            {
               return Ok(_pacienteRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
