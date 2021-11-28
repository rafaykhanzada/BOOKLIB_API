using System.ComponentModel.DataAnnotations;

namespace BOOKLIB_API.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Email is Required"), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}
