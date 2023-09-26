using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthclinic_webapi.Domains
{
    [Table(nameof(Clinica))]
    public class Clinica
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O endereço é obrigatório")]
        public string? Endereco { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "O horário de inicio é obrigatório")]
        public TimeOnly HoraInicio { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "O horário final é obrigatório")]
        public TimeOnly HoraFinal { get; set; }

        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "o CNPJ é obrigatório")]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "o nome fantasia é obrigatória")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "a razao social é obrigatória")]
        public string? RazaoSocial { get; set; }
    }
}
