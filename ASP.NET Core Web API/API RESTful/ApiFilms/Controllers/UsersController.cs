﻿using ApiFilms.Models;
using ApiFilms.Models.Dtos;
using ApiFilms.Respository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiFilms.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _usRepo;
        private readonly IMapper _mapper;
        protected ResponseApi _responseApi;

        public UsersController(IUserRepository usRepo, IMapper mapper)
        {
            _usRepo = usRepo;
            _mapper = mapper;
            this._responseApi = new (); // initialized as dependency injection
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

        [HttpGet("{userId:int}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUser(int userId)
        {
            var itemUser = _usRepo.GetUser(userId);

            if (itemUser == null)
            {
                return NotFound();
            }

            var itemUserDto = _mapper.Map<UserDto>(itemUser);

            return Ok(itemUserDto);
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // arguments : JSON and DTO (User) Object.
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            bool validateUniqueUserNAme = _usRepo.IsUniqueUser(userRegisterDto.UserName);

            if(!validateUniqueUserNAme)
            {
                _responseApi.StatusCode = HttpStatusCode.BadRequest;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add("The user name already exist!");
                return BadRequest(_responseApi);
            }

            var user = await _usRepo.Register(userRegisterDto);

            if (user == null)
            {
                _responseApi.StatusCode = HttpStatusCode.BadRequest;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add("Registration error!");
                return BadRequest(_responseApi);
            }

            _responseApi.StatusCode = HttpStatusCode.OK;
            _responseApi.IsSuccess = true;

            return Ok(_responseApi);

        }


        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // arguments : JSON and DTO (User) Object.
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var responseLogin = await _usRepo.Login(userLoginDto);


            if (responseLogin.User == null || string.IsNullOrEmpty(responseLogin.Token))
            {
                _responseApi.StatusCode = HttpStatusCode.BadRequest;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add("The username or password are incorrect!");
                return BadRequest(_responseApi);
            }


            _responseApi.StatusCode = HttpStatusCode.OK;
            _responseApi.IsSuccess = true;
            _responseApi.Result = responseLogin;

            return Ok(_responseApi);

        }


    }
}
