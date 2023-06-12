using System.ComponentModel.DataAnnotations;

namespace ApiFilms.Models.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is mantatory")]
        [MaxLength(60, ErrorMessage = "Max 100 characters !!!")]
        public string Name { get; set; }

    }
}
