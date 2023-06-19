using System.ComponentModel.DataAnnotations;

namespace ApiFilms.Models.Dtos
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "User-Name is mandatory")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is mandatory")]
        public string Password { get; set; }

    }
}
