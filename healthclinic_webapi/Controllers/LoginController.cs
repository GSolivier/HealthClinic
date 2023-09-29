using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using healthclinic_webapi.Repositories;
using healthclinic_webapi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace healthclinic_webapi.Controllers
{
    /// <summary>
    /// Controlador para armazenar as lógicas de login
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        /// <summary>
        /// Construtor que instancia o objeto do Repository
        /// </summary>
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Endpoint que acessa o método BuscarPorEmailESenha e realiza a autenticação do token de acesso
        /// </summary>
        /// <param name="usuario">ViewModel para pegar o email e senha do usuario</param>
        /// <returns>Retorna um StatusCode(200) - Ok com o token de acesso</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioEncontrado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);

                if (usuarioEncontrado == null)
                {
                    return NotFound("Email ou senha inválidos");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioEncontrado.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioEncontrado.Nome!),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioEncontrado.Email!),
                    new Claim("IdTipoUsuario", usuarioEncontrado.IdTipoUsuario.ToString()),
                    new Claim("CPF", usuarioEncontrado.CPF!),
                    new Claim(ClaimTypes.Role, usuarioEncontrado.TipoUsuario!.Titulo!)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("health-clinic-chave-autenticacao-webapi"));

                var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                    (
                        issuer: "healthclinic_webapi",

                        audience: "healthclinic_webapi",

                        claims: claims,

                        expires: DateTime.Now.AddMinutes(10),

                        signingCredentials: credential
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

                //return Ok(usuarioEncontrado);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
