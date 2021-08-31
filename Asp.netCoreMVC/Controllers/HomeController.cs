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
        private List<Employee> emp;
        public HomeController(ILogger<HomeController> logger)
        {
            emp = new List<Employee>()
        {
            new Employee()
            { EmployeeId =1,FirstName="Neha",LastName="K", Email="Neha.k@gmail.com", Salary=30000, Company="Summit", Dept="IT" },
            new Employee()
            { EmployeeId =2,FirstName="Nitin",LastName="C", Email="Nitin.C@gmail.com", Salary=50000, Company="IBM", Dept="IT" },
            new Employee()
            { EmployeeId =3,FirstName="Madhu",LastName="K", Email="Madhu.K@gmail.com", Salary=20000, Company="HCl", Dept="IT" },
            new Employee()
            { EmployeeId =4,FirstName="Ramesh",LastName="MD", Email="Ramesh.MD@gmail.com", Salary=26700, Company="Tech Mahindra", Dept="BPO" },
            new Employee()
            { EmployeeId =5,FirstName="Chitra",LastName="R", Email="Chitra.R@gmail.com", Salary=25000, Company="Dell", Dept="BPO" },
            new Employee()
            { EmployeeId =6,FirstName="Suresh",LastName="K", Email="Suresh.K@gmail.com", Salary=24500, Company="Infosys", Dept="BPO" },
            new Employee()
            { EmployeeId =7,FirstName="Naina",LastName="H", Email="Naina.H@gmail.com", Salary=30000, Company="Summit", Dept="IT" },
            new Employee()
            { EmployeeId =8,FirstName="Lokesh",LastName="C", Email="Lokesh.C@gmail.com", Salary=90000, Company="IBM", Dept="IT" },
            new Employee()
            { EmployeeId =9,FirstName="John",LastName="K", Email="John.K@gmail.com", Salary=20000, Company="HCl", Dept="IT" },
            new Employee()
            { EmployeeId =10,FirstName="Rajesh",LastName="MD", Email="Rajesh.MD@gmail.com", Salary=26700, Company="Tech Mahindra", Dept="BPO" }

        };
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(emp);
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
