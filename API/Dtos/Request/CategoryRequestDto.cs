using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Request
{
    public class CategoryRequestDto
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(70, ErrorMessage = "El {0} debe tener al menos {2} caracteres.")]
        public string Name { get; set; } = default!;

        public IFormFile? File { get; set; }
    }
}
