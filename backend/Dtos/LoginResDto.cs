using System.ComponentModel.DataAnnotations;

namespace backend.Dtos
{
    public class LoginResDto
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Token { get; set; }
    }
}
