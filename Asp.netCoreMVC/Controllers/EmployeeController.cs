using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.netCoreMVC.Models;

namespace Asp.netCoreMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: EmployeeController
        private readonly IEmployeeRepository _repository = null;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            var result = employeeRepository.getAllEmployee();
            return View(result);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            var result = employeeRepository.GetEmployeeById(id);
            return View(result);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
               // EmployeeRepository employeeRepository = new EmployeeRepository();
                _repository.CreateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _repository.GetEmployeeById(id);
            return View(result);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                _repository.UpdateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
