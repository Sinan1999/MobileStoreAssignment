using System.ComponentModel.DataAnnotations;

namespace MobileDemo.Authentication
{
    public class LoginModel
    {
        [Required]
        public string? User { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
