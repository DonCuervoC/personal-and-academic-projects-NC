using FilmsWebCore5.Models;
using FilmsWebCore5.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsWebCore5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountRepository _accRepo;

        public HomeController(ILogger<HomeController> logger, IAccountRepository accRepo)
        {
            _logger = logger;
            _accRepo = accRepo; 
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet] // Razor view
        public IActionResult Login()
        {
            UserM user = new UserM();
            return View(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
