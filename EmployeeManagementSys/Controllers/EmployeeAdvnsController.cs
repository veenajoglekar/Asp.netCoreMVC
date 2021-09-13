using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSys.DAL.Data;
using EmployeeManagementSys.DAL.Data.Model;
using EmployeeManagementSys.Services.Services;

namespace EmployeeManagementSys.Controllers
{
    public class EmployeeAdvnsController : Controller
    {
        private readonly EmployeeManagementDbContext _context;
        private readonly IEmpAdvnService _empDetAdvnService;
        public EmployeeAdvnsController(EmployeeManagementDbContext context, IEmpAdvnService empDetAdvnService)
        {
            _context = context;
            _empDetAdvnService = empDetAdvnService;
        }

        // GET: EmployeeAdvns
        public async Task<IActionResult> Index()
        {
            var result = await _empDetAdvnService.GetAllEmployee();
            return View(result);
        }

      

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var EmpFamDetail = await _empDetAdvnService.GetEmpDetailsById(id);

            if (EmpFamDetail == null)

            {
                return NotFound();
            }

            return View(EmpFamDetail);
        }

        //GET: EmpFamilyDetAdvns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpFamilyDetAdvns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId, FirstName, LastName")] EmployeeAdvn empDetAdvn)
        {
            if (ModelState.IsValid)
            {
                bool result = await _empDetAdvnService.CreateEmployee(empDetAdvn);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(empDetAdvn);
        }

        // GET: EmpFamilyDetAdvns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empFamilyDetAdvn = await _empDetAdvnService.GetEmpDetailsById(id);
            if (empFamilyDetAdvn == null)
            {
                return NotFound();
            }
            return View(empFamilyDetAdvn);
        }

        // POST: EmpFamilyDetAdvns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,FirstName,LastName")] EmployeeAdvn empDetAdvn)
        {
            if (id != empDetAdvn.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _empDetAdvnService.UpdateEmployee(empDetAdvn);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpDetAdvnExists(empDetAdvn.EmployeeId))
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
            return View(empDetAdvn);
        }

        // GET: EmpFamilyDetAdvns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)

            {
                return NotFound();
            }

            var empFamilyDetAdvn = await _empDetAdvnService.GetEmpDetailsById(id);
            if (empFamilyDetAdvn == null)
            {
                return NotFound();
            }

            return View(empFamilyDetAdvn);
        }

        // POST: EmpFamilyDetAdvns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           await _empDetAdvnService.DeleteEmployee(id);

            return RedirectToAction(nameof(Index));
        }

        private bool EmpDetAdvnExists(int id)
        {
            return _empDetAdvnService.EmployeeAdvnExists(id);
        }
    }
}
