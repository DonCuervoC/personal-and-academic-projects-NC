using ApiFilms.Data;
using ApiFilms.Models;
using ApiFilms.Models.Dtos;
using ApiFilms.Respository.IRepository;

namespace ApiFilms.Respository
{
    public class UserRespository : IUserRepository
    {

        private readonly ApplicationDbContext _db;

        public UserRespository(ApplicationDbContext db)
        {
            _db = db;
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

        public Task<UserLoginResponseDto> Login(UserLoginDto userLoginDto)
        {
            throw new NotImplementedException();
        }

        public Task<User> Register(UserRegisterDto userRegisterDto)
        {
            throw new NotImplementedException();
        }
    }
}
