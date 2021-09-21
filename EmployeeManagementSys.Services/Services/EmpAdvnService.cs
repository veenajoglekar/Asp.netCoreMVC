using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSys.DAL.Data;
using EmployeeManagementSys.DAL.Data.Model;

namespace EmployeeManagementSys.Services.Services
{
        public interface IEmpAdvnService
        {
            public Task<List<EmployeeAdvn>> GetAllEmployee();
            public Task<EmployeeAdvn> GetEmpDetailsById(int? id);

            public Task<bool> CreateEmployee(EmployeeAdvn empDetAdvn);
            public Task UpdateEmployee(EmployeeAdvn empDetAdvn);
            public Task DeleteEmployee(int id);
            public bool EmployeeAdvnExists(int id);

        }
    public class EmpAdvnService : IEmpAdvnService
    {
    
            public async Task<List<EmployeeAdvn>> GetAllEmployee()
            {
                using (var Context = new EmployeeManagementDbContext())
                {

                return await Context.EmployeeAdvn.ToListAsync();
                }
            }





            public async Task<EmployeeAdvn> GetEmpDetailsById(int? id)
            {
                using (var Context = new EmployeeManagementDbContext())
                {
                    return await Context.EmployeeAdvn.FirstOrDefaultAsync(m => m.EmployeeId == id);
                }
            }


            public async Task<bool> CreateEmployee(EmployeeAdvn employeeAdvn)
            {
                using (var Context = new EmployeeManagementDbContext())
                {
                    try
                    {
                        Context.Add(employeeAdvn);
                        await Context.SaveChangesAsync();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    return true;
                }
            }

            public async Task UpdateEmployee(EmployeeAdvn employeeAdvn)
            {
                using (var Context = new EmployeeManagementDbContext())
                {

                    Context.Update(employeeAdvn);
                    await Context.SaveChangesAsync();

                }
            }
       
            public async Task DeleteEmployee(int id)
            {
                using (var Context = new EmployeeManagementDbContext())
                {
                    var empFamDet = await Context.EmployeeAdvn.FindAsync(id);

                    Context.EmployeeAdvn.Remove(empFamDet);
                    await Context.SaveChangesAsync();
                }
            }

            public bool EmployeeAdvnExists(int id)
            {
                using (var Context = new EmployeeManagementDbContext())
                {
                    return Context.EmployeeAdvn.Any(e => e.EmployeeId == id);
                }
            }


        }
    }

