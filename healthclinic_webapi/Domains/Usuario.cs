using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthclinic_webapi.Domains
{
    [Table(nameof(Usuario))]
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "O nome do usuário é obrigatório")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "O email é obrigatório")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "A senha é obrigatória")]
        public string? Senha { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        public DateOnly DataNascimento { get; set; }

        [Column(TypeName = "VARCHAR(11)")]
        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string? CPF { get; set; }

        //ref.Tabela TiposUsuario
        [Required(ErrorMessage = "O ID do tipo de usuário é obrigatório")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        public TiposUsuario? TipoUsuario { get; set; }

    }
}
