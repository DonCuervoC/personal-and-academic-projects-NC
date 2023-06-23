using Microsoft.AspNetCore.Identity;

namespace ApiFilms.Models
{
    public class AppUser : IdentityUser
    {
        //Add custom fields 
        public string Name { get; set; }
        public string City { get; set; }
        //public string Telephone { get; set; }
        public string PostalCode { get; set; }

    }
}
