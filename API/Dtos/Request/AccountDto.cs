using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Request
{
    public class AccountDto : LoginDto
    {

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(90, ErrorMessage = "El {0} debe tener al menos {2} caracteres.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(255, ErrorMessage = "El {0} debe tener al menos {2} caracteres.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(25, ErrorMessage = "El {0} debe tener al menos {2} caracteres.")]
        public string PhoneNumber { get; set; }
    }
}
