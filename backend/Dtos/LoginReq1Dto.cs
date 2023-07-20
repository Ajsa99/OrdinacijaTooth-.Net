using System.ComponentModel.DataAnnotations;

namespace backend.Dtos
{
    public class LoginReq1Dto
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
