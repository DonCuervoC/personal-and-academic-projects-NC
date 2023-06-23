using ApiFilms.Models;
using ApiFilms.Models.Dtos;

namespace ApiFilms.Respository.IRepository
{
    public interface IUserRepository
    {
        // get Users - list users
        ICollection<AppUser> GetUsers();

        AppUser GetUser(string userId);

        bool IsUniqueUser(string user);

        //Specifies that the method is asynchronous and returns a task. A task represents an asynchronous operation that can return a result in the future.
        Task<UserLoginResponseDto> Login(UserLoginDto userLoginDto);

        Task<UserDataDto> Register(UserRegisterDto userRegisterDto);


    }
}
