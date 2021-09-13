using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSys.DAL.Data.Model;
using EmployeeManagementSys.ViewModel;
using Microsoft.AspNetCore.Authorization;
using EmployeeManagementSys.DAL.Data;
using EmployeeManagementSys.Services.Services;

namespace EmployeeManagementSys.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly EmployeeManagementDbContext _context;
        private readonly IEmployeeService _employeeService;

        public EmployeesController(EmployeeManagementDbContext context, IEmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            ViewData["Any"] = await _employeeService.GetAny();

            ViewData["average"] = await _employeeService.GetAverage();
            return View(await _employeeService.GetAllEmployee());
           
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeService.GetEmployeeById(id);


            var employeeFamilyDetails = await _employeeService.GetEmployeeFamilyDetailsById(id);




            if (employee == null || employeeFamilyDetails == null)
            {
                return NotFound();
            }

            EmpFamilyDetailsViewModel empFamilyDetailsViewModel = new EmpFamilyDetailsViewModel();
            empFamilyDetailsViewModel.Employee = employee;
            empFamilyDetailsViewModel.EmployeeFamilyDetails = employeeFamilyDetails;

            ViewBag.Header = "Employee Details";
            return View(empFamilyDetailsViewModel);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,FirstName,LastName,Email,Address,Salary,Role")] Employee employee,
                                                [Bind("id,MemberName,MemberRelation,ContactNumber")] EmployeeFamilyDetails employeeFamilyDetails)
        {

            if (ModelState.IsValid)
            {
                bool result = await _employeeService.CreateEmployee(employee, employeeFamilyDetails);
                if (result)
                {
                    return RedirectToAction(nameof(Index));

                }
            }


            EmpFamilyDetailsViewModel empFamilyDetailsViewModel = new EmpFamilyDetailsViewModel();
            empFamilyDetailsViewModel.Employee = employee;
            empFamilyDetailsViewModel.EmployeeFamilyDetails = employeeFamilyDetails;
            return View(empFamilyDetailsViewModel);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeService.GetEmployeeById(id);
            var employeeFamilyDetails = await _employeeService.GetEmployeeFamilyDetailsById(id);

            if (employee == null || employeeFamilyDetails == null)
            {
                return NotFound();
            }

            EmpFamilyDetailsViewModel empFamilyDetailsViewModel = new EmpFamilyDetailsViewModel();
            empFamilyDetailsViewModel.Employee = employee;
            empFamilyDetailsViewModel.EmployeeFamilyDetails = employeeFamilyDetails;
            return View(empFamilyDetailsViewModel);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,FirstName,LastName,Email,Address,Salary,Role")] Employee employee,
                                                [Bind("id,MemberName,MemberRelation,ContactNumber")] EmployeeFamilyDetails employeeFamilyDetails)
        {

            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeService.UpdateEmployee(employee, employeeFamilyDetails);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            EmpFamilyDetailsViewModel empFamilyDetailsViewModel = new EmpFamilyDetailsViewModel();
            empFamilyDetailsViewModel.Employee = employee;
            empFamilyDetailsViewModel.EmployeeFamilyDetails = employeeFamilyDetails;
            return View(empFamilyDetailsViewModel);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeService.GetEmployeeById(id);
            var employeeFamilyDetails = await _employeeService.GetEmployeeFamilyDetailsById(id);


            //var employee = await _context.employees
            //    .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null || employeeFamilyDetails == null)
            {
                return NotFound();
            }

            EmpFamilyDetailsViewModel empFamilyDetailsViewModel = new EmpFamilyDetailsViewModel();
            empFamilyDetailsViewModel.Employee = employee;
            empFamilyDetailsViewModel.EmployeeFamilyDetails = employeeFamilyDetails;
            return View(empFamilyDetailsViewModel);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           
            await _employeeService.DeleteEmployee(id);
            
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _employeeService.EmployeeExists(id);
        }
    }
}
