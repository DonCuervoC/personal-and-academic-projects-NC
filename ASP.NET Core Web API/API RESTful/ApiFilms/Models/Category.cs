using System.ComponentModel.DataAnnotations;

namespace ApiFilms.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime DateCreation { get; set; }
    }
}
