using ApiFilms.Models.Dtos;
using ApiFilms.Respository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using ApiFilms.Models;

namespace ApiFilms.Controllers
{
    //API controller
    [ApiController]
    //[Route("api/[controller]")] // this is an option
    [Route("api/categories")]

    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _ctRepo;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository ctRepo, IMapper mapper)
        {
            _ctRepo = ctRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCategories()
        {
            var listCategories = _ctRepo.GetCaterories();

            var listCategoryDto = new List<CategoryDto>();

            foreach (var list in listCategories)
            {
                listCategoryDto.Add(_mapper.Map<CategoryDto>(list));
            }
            return Ok(listCategoryDto);
        }

        [HttpGet("{categoryId:int}", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCategory(int categoryId)
        {
            var itemCategory = _ctRepo.GetCategory(categoryId);

            if (itemCategory == null)
            {
                return NotFound();
            }

            var itemCategoryDto = _mapper.Map<CategoryDto>(itemCategory);

            return Ok(itemCategoryDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CategoryDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // arguments : JSON and DTO (Category) Object.
        public IActionResult CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            // check all DTO model requirements (CategoryDto.cs)
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (createCategoryDto == null)
            {
                return BadRequest(ModelState);
            }

            // if finds duplicity
            if (_ctRepo.ExistCategory(createCategoryDto.Name))
            {
                ModelState.AddModelError("", "The category already exists!");
                return StatusCode(404, ModelState);
            }

            var category = _mapper.Map<Category>(createCategoryDto);
            // If the category could not be created
            if (!_ctRepo.CreateCategory(category))
            {
                ModelState.AddModelError("", $"Something went wrong while saving the record {category.Name}!");
                return StatusCode(500, ModelState);
            }
            // Create a new source.
            return CreatedAtRoute("GetCategory", new { categoryId = category.Id }, category);
        }

        [HttpPatch("{categoryId:int}", Name = "UpdatePatchCategory")]
        [ProducesResponseType(201, Type = typeof(CategoryDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // arguments : category id, JSON and DTO (Category) Object.
        public IActionResult UpdatePatchCategory(int categoryId, [FromBody] CategoryDto categoryDto)
        {
            // check all DTO model requirements (CategoryDto.cs)
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (categoryDto == null || categoryId != categoryDto.Id)
            {
                return BadRequest(ModelState);
            }

            var category = _mapper.Map<Category>(categoryDto);
            // If the category could not be created
            if (!_ctRepo.UpdateCategory(category))
            {
                ModelState.AddModelError("", $"Something went wrong while updating the record {category.Name}!");
                return StatusCode(500, ModelState);
            }
            // Create a new source.
            return NoContent();
        }

        [HttpDelete("{categoryId:int}", Name = "DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // arguments : category id, JSON and DTO (Category) Object.
        public IActionResult DeleteCategory(int categoryId)
        {
            // if not found
            if (!_ctRepo.ExistCategory(categoryId))
            {
                return NotFound();
            }

            var category = _ctRepo.GetCategory(categoryId);
            // If the category could not be created
            if (!_ctRepo.DeleteCategory(category))
            {
                ModelState.AddModelError("", $"Something went wrong while deleting the record {category.Name}!");
                return StatusCode(500, ModelState);
            }
            // Create a new source.
            return NoContent();
        }


    }
}
