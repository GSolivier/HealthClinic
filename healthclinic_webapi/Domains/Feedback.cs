﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthclinic_webapi.Domains
{
    [Table(nameof(Feedback))]
    public class Feedback
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "TEXT")]
        public string? Descricao { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "A exibição é obrigatória")]
        public bool Visivel { get; set; }

        //ref.tabela Paciente
        [Required(ErrorMessage = "O ID do Paciente é obrigatório")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

        //ref.tabela Consulta

        [Required(ErrorMessage = "O ID do Consulta é obrigatório")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }

    }
}
