using System.ComponentModel.DataAnnotations;

namespace FilmsWebCore5.Models
{
    // User model for JWT authentication
    public class UserM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "User name is mandatory")]
        public string UserName { get; set; }

        public string Name { get; set; }
        [Required(ErrorMessage = "User name is mandatory")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Password must be between 4 and 10 characters")]
        public string Password { get; set; }

        public string Password2 { get; set; }

        public string Token { get; set; }


    }
}
