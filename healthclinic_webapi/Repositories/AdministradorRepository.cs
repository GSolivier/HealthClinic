using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;

namespace healthclinic_webapi.Repositories
{
    /// <summary>
    /// Repository que herda os métodos da Interdface IAdministradorRepository
    /// </summary>
    public class AdministradorRepository : IAdministradorRepository
    {
        private readonly ClinicContext _clinicContext;

        /// <summary>
        /// Construtor que instancia os métodos da context
        /// </summary>
        public AdministradorRepository()
        {
            _clinicContext = new ClinicContext();
        }

        /// <summary>
        /// Método que cadastrar um novo ADministrador
        /// </summary>
        /// <param name="administrador">Objeto que será cadastrado</param>
        public void Cadastrar(Administrador administrador)
        {
            try
            {
                _clinicContext.Administrador.Add(administrador);

                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para buscas um novo administrador pelo seu ID
        /// </summary>
        /// <param name="id">ID do adm que será buscado</param>
        /// <returns>retorna o objeto encontrado</returns>
        public Administrador BuscarPorId(Guid id)
        {
            try
            {
                Administrador administradorBuscado = _clinicContext.Administrador.
                    Select(adm => new Administrador
                    {
                        Id = adm.Id,
                        Cargo = adm.Cargo,
                        IdUsuario = adm.IdUsuario,
                        Usuario = new Usuario 
                        { 
                            Nome = adm.Usuario!.Nome,
                            Email = adm.Usuario!.Email,
                            IdTipoUsuario = adm.Usuario!.IdTipoUsuario
                        }
                    }
                    
                    ).FirstOrDefault(adm => adm.Id == id)!;

                if (administradorBuscado == null)
                {
                    throw new Exception($"Adm com o id {id} não encontrado!");
                }

                return administradorBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
