using System.ComponentModel.DataAnnotations;

namespace FreelaCashWEB.Models
{
    public class Login
    {
        [Required(ErrorMessage = "O campo {0} e obrigatorio.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "O campo {0} e obrigatorio.")]
        public string Password { get; set; }
    }
}
