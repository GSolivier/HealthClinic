using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using healthclinic_webapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace healthclinic_webapi.Controllers
{
    /// <summary>
    /// Controlador com os endpoints da entidade TiposUsuario
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository;

        /// <summary>
        /// Construtor que instancia o objeto do repositório
        /// </summary>
        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        /// <summary>
        /// Endpoint que acessa o método Cadastrar do TiposUsuarioRepository
        /// </summary>
        /// <param name="tiposUsuario">Objeto com os atributos a serem cadastrados</param>
        /// <returns>Retorna um StatusCode(201) - Created</returns>
        [HttpPost]
        public IActionResult Post(TiposUsuario tiposUsuario)
        {
            try
            {
                _tiposUsuarioRepository.Cadastrar(tiposUsuario);

                return Created("O objeto foi criado", tiposUsuario);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Listar do TiposUsuarioRepository
        /// </summary>
        /// <returns>Retorna um StatusCode(200) - Ok com a lista de objetos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tiposUsuarioRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Atualizar do TiposUsuarioRepository
        /// </summary>
        /// <param name="id">ID do usuário que será atualizado</param>
        /// <param name="tiposUsuario">Objeto com as novas informações</param>
        /// <returns>Retorna um StatusCode(200) - Ok</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TiposUsuario tiposUsuario)
        {
            try
            {
                _tiposUsuarioRepository.Atualizar(id, tiposUsuario);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Deletar do TiposUsuarioRepository
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será deletado</param>
        /// <returns>Retorna um StatusCode(204) - NoContent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tiposUsuarioRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}

