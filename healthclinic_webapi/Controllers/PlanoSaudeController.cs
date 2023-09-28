using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using healthclinic_webapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace healthclinic_webapi.Controllers
{
    /// <summary>
    /// Controlador que armazena os endpoints da entidade PlanoSaude
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PlanoSaudeController : ControllerBase
    {
        private IPlanoSaudeRepository _planoSaudeRepository;

        /// <summary>
        /// Construtor que instancia o objeto do Repository
        /// </summary>
        public PlanoSaudeController()
        {
            _planoSaudeRepository = new PlanoSaudeRepository();
        }

        /// <summary>
        /// Endpoint que acessa o método Cadastrar do PlanoSaudeRepository
        /// </summary>
        /// <param name="planoSaude">Objeto que será cadastrado</param>
        /// <returns>Retorna um StatusCode(201) - Created com o objeto criado</returns>
        [HttpPost]
        public IActionResult Post(PlanoSaude planoSaude)
        {
            try
            {
                _planoSaudeRepository.Cadastrar(planoSaude);

                return Created("Objeto criado com sucesso!", planoSaude);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Listar do PlanoSaudeRepository
        /// </summary>
        /// <returns>Retorna um StatusCode(200) - Ok com a lista de objetos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_planoSaudeRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método BuscarPorId no PlanoSaudeRepository
        /// </summary>
        /// <param name="id">ID do plano de saúde que será buscado</param>
        /// <returns>Retorna um StatusCode(200) - Ok com o objeto encontrado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_planoSaudeRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Atualizar no PlanoSaudeRepository
        /// </summary>
        /// <param name="id">ID do objeto que será atualizado</param>
        /// <param name="planoSaude">Objeto com os novos atributos</param>
        /// <returns>Retorna um StatusCode(200) - Ok</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, PlanoSaude planoSaude)
        {
            try
            {
                _planoSaudeRepository.Atualizar(id, planoSaude);

                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Deletar da PlanoSaudeRepository
        /// </summary>
        /// <param name="id">ID do objeto que será deletado</param>
        /// <returns>Retorna um StatusCode(204) - NoCOntent</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _planoSaudeRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
