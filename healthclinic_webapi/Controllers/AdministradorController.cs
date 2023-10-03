using healthclinic_webapi.Interfaces;
using healthclinic_webapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace healthclinic_webapi.Controllers
{
    /// <summary>
    /// Controlador que tem os enpoints da entidade Administrador
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AdministradorController : ControllerBase
    {
        private IAdministradorRepository _administradorRepository;

        /// <summary>
        /// Construtor que instancia o objeto da Repository
        /// </summary>
        public AdministradorController()
        {
            _administradorRepository = new AdministradorRepository();
        }

        /// <summary>
        /// Enpoint que acessa o método BuscarPorId do AdministradorRepository
        /// </summary>
        /// <param name="id">ID do paciente que sera buscado</param>
        /// <returns>Retorna um StatusCode(200) Ok com o objeto retornado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
               return Ok( _administradorRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
