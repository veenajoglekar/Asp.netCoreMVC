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
    public class EmpDetController : Controller
    {
        private readonly EmployeeManagementDbContext _context;
        private readonly IEmpAdvnService _empAdvnService;
        private readonly IEmpFamDetAdvnService _empFamDetAdvnService;

        public EmpDetController(EmployeeManagementDbContext context, IEmpAdvnService empAdvnService,
            IEmpFamDetAdvnService empFamDetAdvnService)
        {
            _context = context;
            _empAdvnService = empAdvnService;
            _empFamDetAdvnService = empFamDetAdvnService;

        }

        // GET: EmpDet
        public async Task<IActionResult> Index()
        {
            
            var employeeManagementDbContext = _context.EmpFamilyDetAdvn.Include(e => e.EmployeeAdvn);
            return View(await employeeManagementDbContext.ToListAsync());
        }

        // GET: EmpDet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empFamilyDetAdvn = await _context.EmpFamilyDetAdvn
                .Include(e => e.EmployeeAdvn)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empFamilyDetAdvn == null)
            {
                return NotFound();
            }

            return View(empFamilyDetAdvn);
        }

        // GET: EmpDet/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.EmployeeAdvn, "EmployeeId", "FirstName");
            return View();
        }

        // POST: EmpDet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,Email,Salary,Address,Role,MemberName,MemberRelation,ContactNumber,CreatedOn,UpdatedOn")] EmpFamilyDetAdvn empFamilyDetAdvn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empFamilyDetAdvn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.EmployeeAdvn, "EmployeeId", "FirstName", empFamilyDetAdvn.EmployeeId);
            return View(empFamilyDetAdvn);
        }

        // GET: EmpDet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empFamilyDetAdvn = await _context.EmpFamilyDetAdvn.FindAsync(id);
            if (empFamilyDetAdvn == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.EmployeeAdvn, "EmployeeId", "FirstName", empFamilyDetAdvn.EmployeeId);
            return View(empFamilyDetAdvn);
        }

        // POST: EmpDet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,Email,Salary,Address,Role,MemberName,MemberRelation,ContactNumber,CreatedOn,UpdatedOn")] EmpFamilyDetAdvn empFamilyDetAdvn)
        {
            if (id != empFamilyDetAdvn.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empFamilyDetAdvn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpFamilyDetAdvnExists(empFamilyDetAdvn.Id))
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

        // GET: EmpDet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empFamilyDetAdvn = await _context.EmpFamilyDetAdvn
                .Include(e => e.EmployeeAdvn)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empFamilyDetAdvn == null)
            {
                return NotFound();
            }

            return View(empFamilyDetAdvn);
        }

        // POST: EmpDet/Delete/5
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
            return _context.EmpFamilyDetAdvn.Any(e => e.Id == id);
        }
    }
}
