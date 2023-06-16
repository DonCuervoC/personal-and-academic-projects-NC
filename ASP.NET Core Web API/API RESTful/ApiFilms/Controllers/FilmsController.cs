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


    }
}
