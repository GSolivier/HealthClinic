using System.ComponentModel.DataAnnotations;

namespace healthclinic_webapi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O email é obrigatório")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "a Senha é obrigatório")]
        public string? Senha { get; set; }
    }
}
