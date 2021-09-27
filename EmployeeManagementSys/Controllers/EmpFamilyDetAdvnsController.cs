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
    public class EmpFamilyDetAdvnsController : Controller
    {
        private readonly EmployeeManagementDbContext _context;
        private readonly IEmpFamDetAdvnService _empFamDetAdvnService;

        public EmpFamilyDetAdvnsController(EmployeeManagementDbContext context, IEmpFamDetAdvnService empFamDetAdvnService)
        {
            _context = context;
            _empFamDetAdvnService = empFamDetAdvnService;
        }

        // GET: EmpFamilyDetAdvns
        public async Task<ActionResult> Index(string searchBy, string Search, int pageNumber = 1)
        {
            ViewData["JoinTables"] = await _empFamDetAdvnService.JoinTables();
            var results = await _empFamDetAdvnService.GetAllEmployee();
            
            //ViewData["average"] =  await _empFamDetAdvnService.GetAverage();
            if (Search == null)
            {
                return View(await PaginatedList<EmpFamilyDetAdvn>.CreateAsync(results, pageNumber, 3));
            }
            if(searchBy == "Name")
            {
                var data = results.Where
                    (e => e.EmployeeAdvn.FirstName.ToLower().Contains(Search.ToLower()))
                    .ToList();
                return View(await PaginatedList<EmpFamilyDetAdvn>.CreateAsync
                            (data, pageNumber, 3));
            }
            else
            {
                var data = results.Where
                  (e => e.Address.ToLower().Contains(Search.ToLower()))
                  .ToList();
                return View(await PaginatedList<EmpFamilyDetAdvn>.CreateAsync
                            (data, pageNumber, 3));
            }

        }

        // GET: EmpFamilyDetAdvns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var EmpFamDetail = await _empFamDetAdvnService.GetEmpFamDetailsById(id);
           
            if (EmpFamDetail == null)
                
            {
                return NotFound();
            }

            return View(EmpFamDetail);
        }

        //GET: EmpFamilyDetAdvns/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.EmployeeAdvn, "EmployeeId", "FirstName");
            return View();
        }

        // POST: EmpFamilyDetAdvns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,Email,Salary,Address,Role,MemberName," +
            "MemberRelation,ContactNumber,CreatedOn,UpdatedOn")] EmpFamilyDetAdvn empFamilyDetAdvn)
        {
            if (ModelState.IsValid)
            {
                bool result = await _empFamDetAdvnService.CreateEmployee(empFamilyDetAdvn);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["EmployeeId"] = new SelectList(_context.EmployeeAdvn, "EmployeeId", "FirstName", empFamilyDetAdvn.EmployeeId);
            return View(empFamilyDetAdvn);
        }

        // GET: EmpFamilyDetAdvns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empFamilyDetAdvn = await _empFamDetAdvnService.GetEmpFamDetailsById(id);
            if (empFamilyDetAdvn == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.EmployeeAdvn, "EmployeeId", "FirstName", empFamilyDetAdvn.EmployeeId);
         
            return View(empFamilyDetAdvn);
        }

        // POST: EmpFamilyDetAdvns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,Email,Salary,Address,Role," +
            "MemberName,MemberRelation,ContactNumber,CreatedOn,UpdatedOn")] EmpFamilyDetAdvn empFamilyDetAdvn)
        {
            if (id != empFamilyDetAdvn.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _empFamDetAdvnService.UpdateEmployee(empFamilyDetAdvn);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpFamilyDetAdvnExists(empFamilyDetAdvn.EmployeeId))
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
            ViewData["EmployeeId"] = new SelectList(_context.EmployeeAdvn, "EmployeeId", "FirstName", empFamilyDetAdvn.EmployeeId);
            return View(empFamilyDetAdvn);
        }

        // GET: EmpFamilyDetAdvns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)

            {
                return NotFound();
            }

            var empFamilyDetAdvn = await _empFamDetAdvnService.GetEmpFamDetailsById(id);  
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
            var empFamilyDetAdvn = await _context.EmpFamilyDetAdvn.FindAsync(id);
            _context.EmpFamilyDetAdvn.Remove(empFamilyDetAdvn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpFamilyDetAdvnExists(int id)
        {
            return _empFamDetAdvnService.EmpFamilyDetAdvnExists(id);
        }


    }
}
