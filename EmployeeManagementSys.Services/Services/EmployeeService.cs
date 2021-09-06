using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagementSys.DAL.Data;
using EmployeeManagementSys.DAL.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSys.Services.Services
{
    public interface IEmployeeService 
    {
        public Task<List<Employee>> GetAllEmployee();
    }
    public class EmployeeService : IEmployeeService
    {
        public async Task<List<Employee>> GetAllEmployee()
        {
            using (var Context = new EmployeeManagementDbContext())
            {
                return await Context.employees.ToListAsync();
            }
        }
    }
}
