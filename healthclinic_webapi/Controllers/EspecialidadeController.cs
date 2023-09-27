using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using healthclinic_webapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace healthclinic_webapi.Controllers
{
    /// <summary>
    /// Controlador com os endpoints da entidade Especialidade
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EspecialidadeController : ControllerBase
    {
        private IEspecialidadeRepository _especialidadeRepository;

        /// <summary>
        /// Construtor que instancia o objeto do Repository
        /// </summary>
        public EspecialidadeController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        /// <summary>
        /// Endpoint que acessa o método Cadastrar da EspecialidadeRepository
        /// </summary>
        /// <param name="especialidade">Objeto que será cadastrado</param>
        /// <returns>Retorna um StatusCode(201) - Created</returns>
        [HttpPost]
        public IActionResult Post(Especialidade especialidade)
        {
            try
            {
                _especialidadeRepository.Cadastrar(especialidade);

                return Created("objeto criado", especialidade);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Enpoint que acessa o método Listar do EspecialidadeRepository
        /// </summary>
        /// <returns>Retorna um StatusCode(200) - Ok com a lista de objetos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_especialidadeRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Atualizar na EspecialidadeRepository
        /// </summary>
        /// <returns>Retorna um StatusCode(200) - Ok</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Especialidade especialidade)
        {
            try
            {
                _especialidadeRepository.Atualizar(id, especialidade);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
