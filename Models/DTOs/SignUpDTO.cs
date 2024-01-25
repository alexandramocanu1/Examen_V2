using System.ComponentModel.DataAnnotations;

namespace Examen_V2.DTOs
{
    public class SignUpDTO
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
