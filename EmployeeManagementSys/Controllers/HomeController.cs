using EmployeeManagementSys.DAL.Data;
using EmployeeManagementSys.DAL.Data.Models;
using EmployeeManagementSys.Models;
using EmployeeManagementSys.Services.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSys.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly ISharedService _sharedService;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ISharedService sharedService,UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _sharedService = sharedService;
            _userManager = userManager;
           
            
        }

        public IActionResult Index()
        {
            ViewData["content"] = "Welcome";
            return View();

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
