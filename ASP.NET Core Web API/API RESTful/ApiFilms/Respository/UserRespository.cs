﻿using ApiFilms.Data;
using ApiFilms.Models;
using ApiFilms.Models.Dtos;
using ApiFilms.Respository.IRepository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XSystem.Security.Cryptography;

namespace ApiFilms.Respository
{
    public class UserRespository : IUserRepository
    {

        private readonly ApplicationDbContext _db;
        private string secretKey;

        public UserRespository(ApplicationDbContext db, IConfiguration config)
        {
            _db = db;
            secretKey = config.GetValue<string>("ApiSettings:Secret");
        }

        public User GetUser(int userId)
        {
            return _db.User.FirstOrDefault(u => u.Id == userId);
        }

        public ICollection<User> GetUsers()
        {
            return _db.User.OrderBy(u => u.UserName).ToList();
        }

        public bool IsUniqueUser(string user)
        {
            var userDb = _db.User.FirstOrDefault(u => u.UserName == user);

            if (userDb == null)
            {
                return true;
            }
            return false;

        }

        public async Task<User> Register(UserRegisterDto userRegisterDto)
        {

            var passwordEncrypted = getMd5(userRegisterDto.Password);

            User user = new User()
            {
                UserName = userRegisterDto.UserName,
                Password = passwordEncrypted,
                Name = userRegisterDto.Name,
                Role = userRegisterDto.Role
            };

            _db.User.Add(user);

            await _db.SaveChangesAsync();

            user.Password = passwordEncrypted;

            return user;

        }


        public async Task<UserLoginResponseDto> Login(UserLoginDto userLoginDto)
        {
            var passwordEncrypted = getMd5(userLoginDto.Password);

            var user = _db.User.FirstOrDefault(
                u => u.UserName.ToLower() == userLoginDto.UserName.ToLower()
                && u.Password == passwordEncrypted
                );

            if (user == null)
            {
                return new UserLoginResponseDto()
                {
                    Token = "",
                    User = null
                };
            }

            var handleToken = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(secretKey);

            //var signingKey = new SymmetricSecurityKey(key);
            //var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {

                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Role, user.Role),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                //SigningCredentials = signingCredentials
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = handleToken.CreateToken(tokenDescriptor);

            UserLoginResponseDto userLoginResponseDto = new UserLoginResponseDto()
            {
                Token = handleToken.WriteToken(token),
                User = user,
            };

            return userLoginResponseDto;

        }

        //Methode to encrypte password with MD5, its used in acces as in Register.
        private string getMd5(string value)
        {

            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider(); // Create an instance of MD5CryptoServiceProvider to calculate the MD5 hash

            byte[] data = System.Text.Encoding.UTF8.GetBytes(value); // Convert the input string to a byte array using UTF-8 encoding

            data = x.ComputeHash(data); // Compute the MD5 hash of the data

            string resp = ""; // Create an empty string to store the final result

            for (int i = 0; i < data.Length; i++)  // loops through each byte in the data array, converts each byte to its lowercase hexadecimal representation, and adds it to the string resp
                resp += data[i].ToString("x2").ToLower();

            return resp; // Return the final result, which is the MD5 hash as a string
        }
    }
}
