using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthclinic_webapi.Domains
{
    [Table(nameof(TiposUsuario))]
    public class TiposUsuario
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "O titulo do tipo de usuário é obrigatório")]
        public string? Titulo { get; set; }
    }
}
