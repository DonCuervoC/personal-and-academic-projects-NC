using System.ComponentModel.DataAnnotations.Schema;

namespace ApiFilms.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] FilmPath { get; set; }  // This data indicates that the image will be saved directly to the database.
        public string Description { get; set; }
        public int Duration { get; set; }
        public enum ClassificationType { seven, thirteen, sixteen, eighteen }

        public ClassificationType Classification { get; set; }
        public DateTime CreationDate { get; set; }

        [ForeignKey("categoryId")]
        public int categoryId { get; set; }
        public Category Category { get; set; }
    }
}
