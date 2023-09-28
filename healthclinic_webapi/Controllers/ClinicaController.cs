using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using healthclinic_webapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace healthclinic_webapi.Controllers
{
    /// <summary>
    /// Controlador com os endpoints da entidade Clinica
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository;

        /// <summary>
        /// Construtor que instancia o objeto da Repository
        /// </summary>
        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Endpoint que acessa o método Cadastrar na ClinicaRepository
        /// </summary>
        /// <param name="clinica">Objeto que será cadastrado</param>
        /// <returns>Retorna um StatusCode(201) - Created</returns>
        [HttpPost]
        public IActionResult Post(Clinica clinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(clinica);

                return Created("O objeto foi criado", clinica);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
