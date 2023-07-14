using FilmsWebCore5.Models;
using FilmsWebCore5.Repository.IRepository;
using FilmsWebCore5.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Threading.Tasks;

namespace FilmsWebCore5.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // instance of : Category Model
            // 
            return View(new UserU() { });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            // go to repository and use the method, also we add the route stocked in CT as a parameter.
            return Json(new { data = await _userRepository.GetAllAsync(CT.RouteUsersApi) });
        }


    }
}
