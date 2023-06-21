using ApiFilms.Models;
using ApiFilms.Models.Dtos;
using ApiFilms.Respository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
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

        [AllowAnonymous]
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

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(FilmDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

        [Authorize(Roles = "admin")]
        [HttpPatch("{filmId:int}", Name = "UpdatePatchFilm")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // arguments : Film id, JSON and DTO (Film) Object.
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

        [Authorize(Roles = "admin")]
        [HttpDelete("{filmId:int}", Name = "DeleteFilm")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // arguments : Film id, JSON and DTO (Film) Object.
        public IActionResult DeleteFilm(int filmId)
        {
            // if not found
            if (!_filmRepo.ExistFilm(filmId))
            {
                return NotFound();
            }

            var film = _filmRepo.GetFilm(filmId);
            // If the category could not be created
            if (!_filmRepo.DeleteFilm(film))
            {
                ModelState.AddModelError("", $"Something went wrong while deleting the record {film.Name}!");
                return StatusCode(500, ModelState);
            }
            // Create a new source.
            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet("GetFilmsInCategory/{categoryId:int}")]
        public IActionResult GetFilmsInCategory(int categoryId)
        {
            var listFilms = _filmRepo.GetFilmsInCategory(categoryId);

            if (listFilms == null)
            {
                return NotFound();
            }

            var itemFilm = new List<FilmDto>();

            foreach (var item in listFilms)
            {
                itemFilm.Add(_mapper.Map<FilmDto>(item));
            }
            return Ok(itemFilm);
        }

        [AllowAnonymous]
        [HttpGet("FindFilm")]
        public IActionResult FindFilm(string name)
        {
            try
            {
                var result = _filmRepo.FindFilm(name.Trim());
                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while recovering data");
            }

        }


    }
}
