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
            //EmployeeRepository employeeRepository = new EmployeeRepository();
            var result = _repository.getAllEmployee();
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
            var result = _repository.CreateEmployee(employee);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            else
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
            var result = _repository.UpdateEmployee(employee);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = _repository.GetEmployeeById(id);
            return View(result);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee employee)
        {
            var result = _repository.DeleteEmployee(id);
            if(result)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
           
        }
    }
}
