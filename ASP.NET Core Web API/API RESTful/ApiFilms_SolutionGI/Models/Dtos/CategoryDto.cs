using System.ComponentModel.DataAnnotations;

namespace ApiFilms.Models.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }

        //Model Requirements 
        [Required(ErrorMessage = "The name is mantatory")]
        [MaxLength(100, ErrorMessage = "Max 100 characters !!!")]
        public string Name { get; set; }

        public DateTime DateCreation { get; set; }

    }
}
