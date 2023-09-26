using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthclinic_webapi.Domains
{
    [Table(nameof(Administrador))]
    public class Administrador
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "O cargo do ADM na empresa é obrigatório")]
        public string? Cargo { get; set; }

        //ref.tabela Usuario
        [Required(ErrorMessage = "O ID do usuário é obrigatório")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
