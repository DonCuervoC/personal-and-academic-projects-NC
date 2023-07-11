using FilmsWebCore5.Models;
using FilmsWebCore5.Models.ViewModels;
using FilmsWebCore5.Repository.IRepository;
using FilmsWebCore5.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FilmsWebCore5.Controllers
{
    public class FilmsController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFilmRepository _filmRepository;

        public FilmsController(ICategoryRepository categoryRepository, IFilmRepository filmRepository)
        {
            _categoryRepository = categoryRepository;
            _filmRepository = filmRepository;
        }

        [HttpGet]
        // view Razor
        public IActionResult Index()
        {
            // instance of : Film Model
            return View(new Film() { });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFilms()
        {
            // go to repository and use the method, also we add the route stocked in CT as a parameter.
            return Json(new { data = await _filmRepository.GetAllAsync(CT.RouteFilmsApi) });
        }

        [HttpGet]
        // get Category info (from database) ViewModels
        public async Task<IActionResult> Create()
        {
            IEnumerable<Category> npList = (IEnumerable<Category>)await _categoryRepository.GetAllAsync(CT.RouteCategoriesApi);
            // bring category list and film model
            FilmsVM objectVM = new FilmsVM()
            {
                // get category list
                ListCategories = npList.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                // instance model Film
                Film = new Film() 
            };

            return View(objectVM);
        }

        [HttpPost] //From view Create
        [ValidateAntiForgeryToken] // metodo para los formularios, solo se pueden enviar peticiones desde este formulario, mas no utilizando otras texnologias.
        public async Task<IActionResult> Create(Film film)
        {

            IEnumerable<Category> npList = (IEnumerable<Category>)await _categoryRepository.GetAllAsync(CT.RouteCategoriesApi);
            // bring category list and film model
            FilmsVM objectVM = new FilmsVM()
            {
                // get category list
                ListCategories = npList.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                // instance model Film
                Film = new Film()
            };

            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;

                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    //open a layer that let us get the file and save it in memory
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            // copy file that was in fs1 in position 0 of array
                            fs1.CopyTo(ms1);
                            // byte p1  was in null, now its going to be ms1 value
                            p1 = ms1.ToArray();
                        }
                    }
                    film.FilmPath = p1;
                }
                else
                {
                    return View(objectVM);
                }
                await _filmRepository.CreateAsync(CT.RouteFilmsApi, film);
                return RedirectToAction(nameof(Index));
            }
            // back to the form view
            return View(objectVM);
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
