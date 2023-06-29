using System.ComponentModel.DataAnnotations;
using System;

namespace FilmsWebCore5.Models
{
    public class Category
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Name is mandatory")]
        public string Name { get; set; }

        public DateTime DateCreation { get; set; }

    }
}
