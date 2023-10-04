using healthclinic_webapi.Domains;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace healthclinic_webapi.ViewModels
{
    /// <summary>
    /// ViewModel para o cadastro de uma nova consulta
    /// </summary>
    public class ConsultaViewModel
    {
        [Required(ErrorMessage = "A data da consulta é obrigatória")]
        public DateOnly Data { get; set; }

        [Required(ErrorMessage = "A hora da consulta é obrigatória")]
        public TimeOnly Hora { get; set; }

        [Required(ErrorMessage = "A descrição da consulta é obrigatória")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O ID do adm é obrigatório")]
        public Guid IdAdministrador { get; set; }

        [Required(ErrorMessage = "O ID do Paciente é obrigatório")]
        public Guid IdPaciente { get; set; }

        [Required(ErrorMessage = "O ID do Medico é obrigatório")]
        public Guid IdMedico { get; set; }

    }
}
