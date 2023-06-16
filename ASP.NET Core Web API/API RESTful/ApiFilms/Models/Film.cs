using System.ComponentModel.DataAnnotations.Schema;

namespace ApiFilms.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FilmPath { get; set; }
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
