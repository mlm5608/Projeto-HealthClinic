using System.ComponentModel.DataAnnotations;

namespace webapi.healthClinic.miguel.VielModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória")]
        public string Senha { get; set; }
    }
}
