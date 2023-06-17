using ApiFilms.Models;
using ApiFilms.Models.Dtos;
using ApiFilms.Respository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFilms.Controllers
{
    [Route("api/films")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmRepository _filmRepo;
        private readonly IMapper _mapper;

        public FilmsController(IFilmRepository filmRepo, IMapper mapper)
        {
            _filmRepo = filmRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetFilms()
        {
            var listFilms = _filmRepo.GetFilms();

            var listFilmDto = new List<FilmDto>();

            foreach (var list in listFilms)
            {
                listFilmDto.Add(_mapper.Map<FilmDto>(list));
            }
            return Ok(listFilmDto);
        }

        [HttpGet("{filmId:int}", Name = "GetFilm")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetFilm(int filmId)
        {
            var itemFilm = _filmRepo.GetFilm(filmId);

            if (itemFilm == null)
            {
                return NotFound();
            }

            var itemFilmDto = _mapper.Map<FilmDto>(itemFilm);

            return Ok(itemFilmDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(FilmDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // arguments : JSON and DTO (Film) Object.
        public IActionResult CreateFilm([FromBody] FilmDto filmDto)
        {
            // check all DTO model requirements (FilmDto.cs)
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (filmDto == null)
            {
                return BadRequest(ModelState);
            }

            // if finds duplicity
            if (_filmRepo.ExistFilm(filmDto.Name))
            {
                ModelState.AddModelError("", "The Film already exists!");
                return StatusCode(404, ModelState);
            }

            var film = _mapper.Map<Film>(filmDto);
            // If the Film could not be created
            if (!_filmRepo.CreateFilm(film))
            {
                ModelState.AddModelError("", $"Something went wrong while saving the record {film.Name}!");
                return StatusCode(500, ModelState);
            }
            // Create a new source.
            return CreatedAtRoute("GetFilm", new { filmId = film.Id }, film);
        }

        [HttpPatch("{filmId:int}", Name = "UpdatePatchFilm")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // arguments : category id, JSON and DTO (Category) Object.
        public IActionResult UpdatePatchFilm(int filmId, [FromBody] FilmDto filmDto)
        {
            // check all DTO model requirements (CategoryDto.cs)
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var film = _mapper.Map<Film>(filmDto);
            // If the category could not be created
            if (!_filmRepo.UpdateFilm(film))
            {
                ModelState.AddModelError("", $"Something went wrong while updating the record {film.Name}!");
                return StatusCode(500, ModelState);
            }
            // Create a new source.
            return NoContent();
        }

    }
}
