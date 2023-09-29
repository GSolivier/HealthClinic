using System.ComponentModel.DataAnnotations;

namespace healthclinic_webapi.DTOs
{
    public class UsuarioMedicoDTO
    {

        [Required(ErrorMessage = "O nome do usuário é obrigatório")]
        public string? Nome { get; set; }


        [Required(ErrorMessage = "O email é obrigatório")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "A senha é obrigatória")]
        public string? Senha { get; set; }


        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        public DateOnly DataNascimento { get; set; }


        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string? CPF { get; set; }

        [Required(ErrorMessage = "O ID do tipo de usuário é obrigatório")]
        public Guid IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "O ID da clinica é obrigatório")]
        public Guid IdClinica { get; set; }

        [Required(ErrorMessage = "O ID da especialidade é obrigatória")]
        public Guid IdEspecialidade { get; set; }

        [Required(ErrorMessage = "O numero do CRM é obrigatório")]
        public string? CRM { get; set; }
    }
}
