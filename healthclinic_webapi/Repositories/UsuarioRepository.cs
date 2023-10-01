using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using healthclinic_webapi.Utils;

namespace healthclinic_webapi.Repositories
{
    /// <summary>
    /// Repository que herda os métodos da interface IUsuarioRepository
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ClinicContext _clinicContext;

        /// <summary>
        /// Construtor que instancia o objeto da context
        /// </summary>
        public UsuarioRepository()
        {
            _clinicContext = new ClinicContext();
        }

        /// <summary>
        /// Método para cadastrar um novo usuário
        /// </summary>
        /// <param name="usuario">Objeto que será cadastrado</param>
        public void Cadastrar(Usuario usuario)
        {
            try
            {
                Usuario usuarioExistente = _clinicContext.Usuario.FirstOrDefault(u => u.Email == usuario.Email)!;

                if (usuarioExistente != null)
                {
                    throw new Exception("Email ja cadastrado!");
                }

                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _clinicContext.Add(usuario);

                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para buscar um usuário pelo seu Email e Senha
        /// </summary>
        /// <param name="email">Email do usuário que será buscado</param>
        /// <param name="senha">Senha do usuário que será buscada</param>
        /// <returns>Retorna o objeto encontrado</returns>
        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _clinicContext.Usuario
                    .Select(u => new Usuario
                    {
                        Id = u.Id,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,
                        DataNascimento = u.DataNascimento,
                        CPF = u.CPF,
                        IdTipoUsuario = u.IdTipoUsuario,
                        TipoUsuario = new TiposUsuario
                        {
                            Titulo = u.TipoUsuario!.Titulo
                        }

                    }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado == null)
                {
                    throw new Exception("Email e/ou Senha incorretos.");
                }

                bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                if (confere)
                {
                    return usuarioBuscado;
                }

                throw new Exception("Email e/ou Senha incorretos.");
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para buscar um usuário pelo seu ID
        /// </summary>
        /// <param name="id">ID do usário que será buscado</param>
        /// <returns>Retorna o objeto encontrado</returns>
        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _clinicContext.Usuario
                    .Select(u => new Usuario
                    {
                        Id = u.Id,
                        Nome = u.Nome,
                        Email = u.Email,
                        DataNascimento = u.DataNascimento,
                        TipoUsuario = new TiposUsuario
                        {
                            Titulo = u.TipoUsuario!.Titulo
                        }


                    }).FirstOrDefault(u => u.Id == id)!;

                if (usuarioBuscado == null)
                {
                    throw new Exception("O usuário não foi encontrado");
                }

                return usuarioBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
