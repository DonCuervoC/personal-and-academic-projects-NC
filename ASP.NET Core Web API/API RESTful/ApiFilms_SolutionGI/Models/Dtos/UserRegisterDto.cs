using System.ComponentModel.DataAnnotations;

namespace ApiFilms.Models.Dtos
{
    public class UserRegisterDto
    {

        [Required(ErrorMessage = "User-Name is mandatory")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Name is mandatory")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Password is mandatory")]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
