using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSys.DAL.Data;
using EmployeeManagementSys.DAL.Data.Model;
using EmployeeManagementSys.Services.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSys.Services.Services
{
    public interface IEmpFamDetAdvnService
    {
        public Task<List<EmpFamilyDetAdvn>> GetAllEmployee();
        public Task<EmpFamilyDetAdvn> GetEmpFamDetailsById(int? id);
     
        public Task<bool> CreateEmployee(EmpFamilyDetAdvn empFamilyDetAdvn);
        public Task UpdateEmployee(EmpFamilyDetAdvn empFamilyDetAdvn);
       //public Task DeleteEmployee(int id);
        public bool EmpFamilyDetAdvnExists(int id);





    }
    public class EmpAdvnFamilyDetService : IEmpFamDetAdvnService
    {
        public async Task<List<EmpFamilyDetAdvn>> GetAllEmployee()
        {
            using (var Context = new EmployeeManagementDbContext())
            {
                return await Context.EmpFamilyDetAdvn.Include(e => e.EmployeeAdvn).ToListAsync();
            }
        }

       



        public async Task<EmpFamilyDetAdvn> GetEmpFamDetailsById(int? id)
        {
            using (var Context = new EmployeeManagementDbContext())
            {
                // var empFamilyDetAdvn = await _context.EmpFamilyDetAdvn
                //.Include(e => e.EmployeeAdvn)
                //.FirstOrDefaultAsync(m => m.Id == id);
                //var result = ;
                return await Context.EmpFamilyDetAdvn.Include(e => e.EmployeeAdvn)
                    .FirstOrDefaultAsync(m => m.Id == id); 
            }
        }

        



        public async Task<bool> CreateEmployee(EmpFamilyDetAdvn empFamilyDetAdvn)
        {
            using (var Context = new EmployeeManagementDbContext())
            {
                try
                {
                    Context.Add(empFamilyDetAdvn);
                    await Context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task UpdateEmployee(EmpFamilyDetAdvn empFamilyDetAdvn)
        {
            using (var Context = new EmployeeManagementDbContext())
            {

                Context.Update(empFamilyDetAdvn);
                await Context.SaveChangesAsync();

            }
        }
        //var empFamilyDetAdvn = await _context.EmpFamilyDetAdvn.FindAsync(id);
        //_context.EmpFamilyDetAdvn.Remove(empFamilyDetAdvn);
        //    await _context.SaveChangesAsync();
        public async Task DeleteEmployee(int id)
        {
            using (var Context = new EmployeeManagementDbContext())
            {
                var empFamDet = await Context.EmpFamilyDetAdvn.FindAsync(id);

                Context.EmpFamilyDetAdvn.Remove(empFamDet);
                await Context.SaveChangesAsync();
            }
        }

        public bool EmpFamilyDetAdvnExists(int id)
        {
            using (var Context = new EmployeeManagementDbContext())
            {
                return Context.EmpFamilyDetAdvn.Any(e => e.EmployeeId == id);
            }
        }


    }
}

