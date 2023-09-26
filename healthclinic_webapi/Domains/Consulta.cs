using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthclinic_webapi.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data da consulta é obrigatória")]
        public DateOnly Data { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "A hora da consulta é obrigatória")]
        public TimeOnly Hora { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição da consulta é obrigatória")]
        public string? Descricao { get; set; }

        //ref.Tabela Administrador
        [Required(ErrorMessage = "O ID do adm é obrigatório")]
        public Guid IdAdministrador { get; set; }

        [ForeignKey(nameof(IdAdministrador))]
        public Administrador? Administrador { get; set; }

        //ref.tabela Paciente
        [Required(ErrorMessage = "O ID do Paciente é obrigatório")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

        //ref.tabela Medico
        [Required(ErrorMessage = "O ID do Medico é obrigatório")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }

        //ref.tabela Feedback
        [Required(ErrorMessage = "O ID do Feedback é obrigatório")]
        public Guid IdFeedback { get; set; }

        [ForeignKey(nameof(IdFeedback))]
        public Feedback? Feedback { get; set; }
    }
}
