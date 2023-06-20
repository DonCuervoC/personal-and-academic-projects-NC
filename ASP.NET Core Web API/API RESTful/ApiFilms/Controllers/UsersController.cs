using ApiFilms.Models.Dtos;
using ApiFilms.Respository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFilms.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _usRepo;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository usRepo, IMapper mapper)
        {
            _usRepo = usRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUserss()
        {
            var listUsers = _usRepo.GetUsers();

            var listUsersDto = new List<UserDto>();

            foreach (var list in listUsers)
            {
                listUsersDto.Add(_mapper.Map<UserDto>(list));
            }
            return Ok(listUsersDto);
        }

    }
}
