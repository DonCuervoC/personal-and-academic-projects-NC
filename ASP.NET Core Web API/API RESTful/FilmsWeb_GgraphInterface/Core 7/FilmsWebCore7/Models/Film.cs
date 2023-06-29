using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace FilmsWebCore5.Models
{
    public class Film
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is mandatory")]
        public string Name { get; set; }
        public byte[] FilmPath { get; set; }  // This data indicates that the image will be saved directly to the database.
        [Required(ErrorMessage = "Description is mandatory")]
        public string Description { get; set; }
        public int Duration { get; set; }
        public enum ClassificationType { seven, thirteen, sixteen, eighteen }

        public ClassificationType Classification { get; set; }
        public DateTime CreationDate { get; set; }

        public int categoryId { get; set; }
        public Category Category { get; set; }
    }
}
