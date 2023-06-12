using ApiFilms.Models.Dtos;
using ApiFilms.Respository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


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
    }
}
