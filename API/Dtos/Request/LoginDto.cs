using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Request
{
    public class LoginDto
    {
        [EmailAddress(ErrorMessage = "El email ingresado no es valido")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(255, ErrorMessage = "El {0} debe tener al menos {2} caracteres.", MinimumLength = 8)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(255, ErrorMessage = "El {0} debe tener al menos {2} caracteres.", MinimumLength = 8)]
        public string Password { get; set; }
    }
}
