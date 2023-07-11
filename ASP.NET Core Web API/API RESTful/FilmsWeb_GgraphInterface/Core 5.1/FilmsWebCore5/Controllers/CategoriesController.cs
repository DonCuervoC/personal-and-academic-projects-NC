using FilmsWebCore5.Models;
using FilmsWebCore5.Repository.IRepository;
using FilmsWebCore5.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
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
            return Json(new { data = await _categoryRepository.GetAllAsync(CT.RouteCategoriesApi) });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //From view Create
        [ValidateAntiForgeryToken] // metodo para los formularios, solo se pueden enviar peticiones desde este formulario, mas no utilizando otras texnologias.
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.CreateAsync(CT.RouteCategoriesApi, category);
                return RedirectToAction(nameof(Index));
            }
            // back to the form view
            return View();
        }

        [HttpGet] //From view Edith
        public async Task<IActionResult> Edit(int? id)
        {
            Category itemCategory = new Category();

            if (id == null)
            {
                Console.WriteLine("ID is null");
                return NotFound();
            }

            itemCategory = await _categoryRepository.GetAsync(CT.RouteCategoriesApi, id.GetValueOrDefault());

            if (itemCategory == null)
            {
                Console.WriteLine("Category not found");
                return NotFound();
            }

            return View(itemCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update (Category category)
        {
            if (ModelState.IsValid)
            {
            //https://localhost:7153/api/categories/8
                await _categoryRepository.UpdateAsync(CT.RouteCategoriesApi + "/" + category.Id , category);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
           // var monURL = CT.RouteCategoriesApi + "/" + id;
            var status = await _categoryRepository.DeleteAsync(CT.RouteCategoriesApi , id);

            if (status)
            {

                return Json(new { success = true, message = "Deleted OK" });
            }
            return Json(new { success = false, message = "Something went wrong while deleting" });
        }


    }
}
