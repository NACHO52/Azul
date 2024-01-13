using Azul.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace Azul.Shared
{
    public class LoginDTO
    {
        [Required(ErrorMessageResourceName = "RequiredError", ErrorMessageResourceType = typeof(Text))]
        public string Username { get; set; }

        [Required(ErrorMessageResourceName = "RequiredError", ErrorMessageResourceType = typeof(Text))]
        public string Password { get; set; }
    }
}