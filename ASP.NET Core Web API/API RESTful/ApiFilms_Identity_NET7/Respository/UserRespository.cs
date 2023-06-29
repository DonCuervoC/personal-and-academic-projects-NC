using ApiFilms.Data;
using ApiFilms.Models;
using ApiFilms.Models.Dtos;
using ApiFilms.Respository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
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

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public UserRespository(ApplicationDbContext db, IConfiguration config, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _db = db;
            secretKey = config.GetValue<string>("ApiSettings:Secret");
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public AppUser GetUser(string userId)
        {
            return _db.AppUser.FirstOrDefault(u => u.Id == userId);
        }

        public ICollection<AppUser> GetUsers()
        {
            return _db.AppUser.OrderBy(u => u.UserName).ToList();
        }

        public bool IsUniqueUser(string user)
        {
            var userDb = _db.AppUser.FirstOrDefault(u => u.UserName == user);

            if (userDb == null)
            {
                return true;
            }
            return false;

        }

        public async Task<UserDataDto> Register(UserRegisterDto userRegisterDto)
        {

           // var passwordEncrypted = getMd5(userRegisterDto.Password);

            AppUser user = new AppUser()
            {
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.UserName,
                NormalizedEmail = userRegisterDto.UserName.ToUpper(),
                Name = userRegisterDto.Name
            };

            /*
            _db.User.Add(user);
            await _db.SaveChangesAsync();
            user.Password = passwordEncrypted;
            return user; */

            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);
            if(result.Succeeded)
            {
                //Only first time and is for create roles
                if(!_roleManager.RoleExistsAsync("admin").GetAwaiter().GetResult())
                {
                    await _roleManager.CreateAsync(new IdentityRole("admin"));
                    await _roleManager.CreateAsync(new IdentityRole("registered"));
                }

                // Only for users I decided to make admin => Uncomente next line "admin" and coment "registered" 
                await _userManager.AddToRoleAsync(user, "admin");
                //await _userManager.AddToRoleAsync(user, "registered");

                var userReturned = _db.AppUser.FirstOrDefault(u => u.UserName == userRegisterDto.UserName);

                //Option1
                /*
                return new UserDataDto()
                {
                    Id = userReturned.Id,
                    UserName = userReturned.UserName,
                    Name = userReturned.Name
                };
                */

                //Option2
                return _mapper.Map<UserDataDto>(userReturned);

            }

            return new UserDataDto();
        }


        public async Task<UserLoginResponseDto> Login(UserLoginDto userLoginDto)
        {
            //var passwordEncrypted = getMd5(userLoginDto.Password);
            /*var user = _db.AppUser.FirstOrDefault(
              u => u.UserName.ToLower() == userLoginDto.UserName.ToLower()
              && u.Password == passwordEncrypted
              ); */

            var user = _db.AppUser.FirstOrDefault( u => u.UserName.ToLower() == userLoginDto.UserName.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(user, userLoginDto.Password);

            if (user == null || isValid == false)
            {
                return new UserLoginResponseDto()
                {
                    Token = "",
                    User = null
                };
            }

            //User exist, we can process the login
            var roles = await _userManager.GetRolesAsync(user);

            var handleToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {

                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Role, roles.FirstOrDefault()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = handleToken.CreateToken(tokenDescriptor);

            UserLoginResponseDto userLoginResponseDto = new UserLoginResponseDto()
            {
                Token = handleToken.WriteToken(token),
                User = _mapper.Map<UserDataDto>(user)
            };

            return userLoginResponseDto;
        }

        //Methode to encrypte password with MD5, its used in acces as in Register.
        /*
        private string getMd5(string value)
        {

            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider(); // Create an instance of MD5CryptoServiceProvider to calculate the MD5 hash

            byte[] data = System.Text.Encoding.UTF8.GetBytes(value); // Convert the input string to a byte array using UTF-8 encoding

            data = x.ComputeHash(data); // Compute the MD5 hash of the data

            string resp = ""; // Create an empty string to store the final result

            for (int i = 0; i < data.Length; i++)  // loops through each byte in the data array, converts each byte to its lowercase hexadecimal representation, and adds it to the string resp
                resp += data[i].ToString("x2").ToLower();

            return resp; // Return the final result, which is the MD5 hash as a string  
        } */
    }
}
