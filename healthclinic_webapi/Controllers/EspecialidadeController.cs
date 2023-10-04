using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using healthclinic_webapi.Repositories;
using Microsoft.AspNetCore.Authorization;
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
        //[Authorize(Roles = "Administrador")]
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
        //[Authorize(Roles = "Administrador, Paciente, Medico")]
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
        /// Endpoint que acessa o método BuscarPorId do EspecialidadeRepository
        /// </summary>
        /// <param name="id">ID do objeto que será buscado</param>
        /// <returns>Retorna um StatusCode(200) - Ok com o objeto encontrado</returns>
        [HttpGet("{id}")]
        //[Authorize(Roles = "Administrador,")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_especialidadeRepository.BuscarPorId(id));
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
        //[Authorize(Roles = "Administrador")]
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

        /// <summary>
        /// Endpoint que acessa o método Deletar da EspecialidadeRepository
        /// </summary>
        /// <param name="id">ID do usuário que será deletada</param>
        /// <returns>Retorna um StatusCode(204) - NoContent</returns>
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _especialidadeRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
