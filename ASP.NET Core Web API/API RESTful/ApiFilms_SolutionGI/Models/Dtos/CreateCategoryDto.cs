using System.ComponentModel.DataAnnotations;

namespace ApiFilms.Models.Dtos
{
    public class CreateCategoryDto
    {
        //This validationt is importa, otherwise we create it with an empty name
        [Required(ErrorMessage = "The name is mantatory")]
        [MaxLength(60, ErrorMessage = "Max 100 characters !!!")]
        public string Name { get; set; }

    }
}
