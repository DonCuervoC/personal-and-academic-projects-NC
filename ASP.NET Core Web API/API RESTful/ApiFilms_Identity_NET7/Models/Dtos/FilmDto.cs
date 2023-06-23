using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiFilms.Models.Dtos
{
    /* Cuando se va a crear una nueva pelicula, no se utiliza el modelo pelicula, se utiliza el DTO y 
     * si cumple las validaciones entonces este se conecta, llama a la pelicula y le pasa los datos, 
     * luego se guarda en la base de datos y se guarda el recurso a travez de la API
     * En todo momento el DTO es el que esta expiesto en la API */
    public class FilmDto
    {
        //Model Requirements 
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is mantatory")]
        public string Name { get; set; }

        public string FilmPath { get; set; }

        [Required(ErrorMessage = "The description is mantatory")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The duration is mantatory")]
        public int Duration { get; set; }

        public enum ClassificationType { seven, thirteen, sixteen, eighteen }
        public ClassificationType Classification { get; set; }

        public DateTime CreationDate { get; set; }

        public int categoryId { get; set; }


    }
}
