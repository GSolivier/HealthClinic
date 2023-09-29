using healthclinic_webapi.Domains;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace healthclinic_webapi.DTOs
{
    public class UsuarioPacienteDTO
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


        //Paciente

        [Required(ErrorMessage = "O ID do tipo de usuário é obrigatório")]
        public Guid IdTipoUsuario { get; set; }


        [Required(ErrorMessage = "O ID do plano de saude é obrigatório")]
        public Guid IdPlanoSaude { get; set; }

        [Required(ErrorMessage = "O endereço do paciente é obrigatório")]
        public string? Endereco { get; set; }



    }
}
