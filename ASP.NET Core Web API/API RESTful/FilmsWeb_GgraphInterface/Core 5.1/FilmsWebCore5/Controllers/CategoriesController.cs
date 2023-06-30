using FilmsWebCore5.Models;
using FilmsWebCore5.Repository.IRepository;
using FilmsWebCore5.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmsWebCore5.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // instance of : Category Model
            // 
            return View(new Category() { });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            // go to repository and use the method, also we add the route stocked in CT as a parameter.
            return Json( new { data = await _categoryRepository.GetAllAsync( CT.RouteCategoriesApi )});
        }
    }
}
