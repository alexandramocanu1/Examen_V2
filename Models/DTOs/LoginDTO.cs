using System.ComponentModel.DataAnnotations;

namespace Examen_V2.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
