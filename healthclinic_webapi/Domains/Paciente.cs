using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthclinic_webapi.Domains
{
    [Table(nameof(Paciente))]
    public class Paciente
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O endereço do paciente é obrigatório")]
        public string? Endereco { get; set; }

        //ref.tabela Usuario
        [Required(ErrorMessage = "O ID do usuário é obrigatório")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        //ref.tabela PlanoSaude
        [Required(ErrorMessage = "O ID do plano de saude é obrigatório")]
        public Guid IdPlanoSaude { get; set; }

        [ForeignKey(nameof(IdPlanoSaude))]
        public PlanoSaude? PlanoSaude { get; set; }
    }
}
