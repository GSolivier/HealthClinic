using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthclinic_webapi.Domains
{
    [Table(nameof(PlanoSaude))]
    public class PlanoSaude
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "O titulo do plano de saúde é obrigatório")]
        public string? Titulo { get; set; }
    }
}
