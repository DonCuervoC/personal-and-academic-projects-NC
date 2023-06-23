using System.ComponentModel.DataAnnotations;

namespace ApiFilms.Models.Dtos
{
    public class UserDataDto
    {
        /*Same names as in a DB */
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

    }
}
