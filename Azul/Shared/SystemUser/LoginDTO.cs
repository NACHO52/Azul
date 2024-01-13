using System.ComponentModel.DataAnnotations;

namespace Azul.Shared
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}