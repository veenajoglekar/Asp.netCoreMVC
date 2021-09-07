using Asp.netCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //public List<string> Student = new List<string>();
        private readonly IEmployeeRepository _repository = null;

        public HomeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            List<Employee> emp = _repository.getAllEmployee();
            ViewData["EmployeeList"] = emp;
            //ViewBag.EmployeeList();

            //Student.Add("Jignesh");
            //Student.Add("Tejas");
            //Student.Add("Rakesh");

            //ViewData["Student"] = Student;
            //ViewBag.Student = Student;

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
