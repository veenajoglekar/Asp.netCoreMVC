using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSys.DAL.Data;
using EmployeeManagementSys.DAL.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSys.Services.Services
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetAllEmployee();
        public Task<Employee> GetEmployeeById(int? id);
        public Task<EmployeeFamilyDetails> GetEmployeeFamilyDetailsById(int? id);
        public Task<bool> CreateEmployee(Employee employee, EmployeeFamilyDetails employeeFamilyDetails);
        public Task UpdateEmployee(Employee employee, EmployeeFamilyDetails employeeFamilyDetails);
        public Task DeleteEmployee(int id);
        public bool EmployeeExists(int id);
        public Task<double> GetAverage();
        public Task<bool> GetAny();





    }
    public class EmployeeService : IEmployeeService
    {
        public async Task<List<Employee>> GetAllEmployee()
        {
            using (var Context = new EmployeeManagementDbContext())
            {
                //var result = await Context.employees.OrderBy(e => e.FirstName)
                //                    .ThenBy(e => e.LastName).ToListAsync();
                //return result;

                //sort first name in ascending order and for same name sort last name in ascending order.
                //ThenBy: extension methods are used for sorting on multiple fields.



                var result = await Context.employees.OrderBy(e => e.FirstName)
                                    .ThenByDescending(e => e.LastName).ToListAsync();
                return result;
                //sort first name in ascending order and for same name sort last name in descending order.


                
            }
        }

        public async Task<bool> GetAny()
        {
            using (var Context = new EmployeeManagementDbContext())
            {
                var empany = await Context.employees.ToListAsync();
                return empany.Any(e => e.Salary > 20000);
            }
        }
        public async Task<double> GetAverage()
        {
            using (var Context = new EmployeeManagementDbContext())
            {
                var avg = await Context.employees.ToListAsync();
                return avg.Average(e => e.Salary);
            }
        }



        public async Task<Employee> GetEmployeeById(int? id)
        {
            using (var Context = new EmployeeManagementDbContext())
            {
                return await Context.employees.FirstOrDefaultAsync(m => m.EmployeeId == id);
            }
        }

        public async Task<EmployeeFamilyDetails> GetEmployeeFamilyDetailsById(int? id)
        {
            using (var Context = new EmployeeManagementDbContext())
            {
                return await Context.EmployeeFamilyDetails.FirstOrDefaultAsync(m => m.id == id);
            }
        }

        public async Task<bool> CreateEmployee(Employee employee, EmployeeFamilyDetails employeeFamilyDetails)
        {
            using (var Context = new EmployeeManagementDbContext())
            {
                try
                {
                    Context.Add(employee);
                    Context.Add(employeeFamilyDetails);
                    await Context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task UpdateEmployee(Employee employee, EmployeeFamilyDetails employeeFamilyDetails)
        {
            using (var Context = new EmployeeManagementDbContext())
            {

                Context.Update(employee);
                Context.Update(employeeFamilyDetails);
                await Context.SaveChangesAsync();

            }
        }

       public async Task DeleteEmployee(int id)
        {
            var employee = await GetEmployeeById(id);
            var employeeFamilyDetails = await GetEmployeeFamilyDetailsById(id);
            using (var Context = new EmployeeManagementDbContext())
            {
                Context.employees.Remove(employee);
                Context.EmployeeFamilyDetails.Remove(employeeFamilyDetails);
                await Context.SaveChangesAsync();
            }
        }

        public bool EmployeeExists(int id)
        {
            using (var Context = new EmployeeManagementDbContext())
            {
                return Context.employees.Any(e => e.EmployeeId == id);
            }
        }


    }
}
