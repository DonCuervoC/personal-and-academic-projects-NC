using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;

namespace FilmsWebCore5.Models.ViewModels
{
    public class FilmsVM
    {
        // combo box with category list <SelectListItem>
        public IEnumerable <SelectListItem> ListCategories { get; set; }
       
        //Film model
        public Film Film { get; set; }


    }
}
