using healthclinic_webapi.Interfaces;
using healthclinic_webapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace healthclinic_webapi.Controllers
{
    /// <summary>
    /// Controlador com os endpoints da entidade Feedback
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FeedbackController : ControllerBase
    {
        private IFeedbackRepository _feedbackRepository;

        /// <summary>
        /// Construtor que instancia o objeto da repository
        /// </summary>
        public FeedbackController()
        {
            _feedbackRepository = new FeedbackRepository();
        }

        /// <summary>
        /// Endpoint que acessa o método BuscarPorIdConsulta do FeedbackRepository
        /// </summary>
        /// <param name="idConsulta">ID da consulta que o feedbakc será buscado</param>
        /// <returns>Retorna um StatusCode(200) - Ok</returns>
        [HttpGet("{idConsulta}")]
        public IActionResult GetByIdConsulta(Guid idConsulta)
        {
            try
            {
                return Ok(_feedbackRepository.BuscarPorIdConsulta(idConsulta));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
