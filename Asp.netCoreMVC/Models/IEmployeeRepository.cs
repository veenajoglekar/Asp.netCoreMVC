using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netCoreMVC.Models
{
    public interface IEmployeeRepository
    {
        public List<Employee> getAllEmployee();
        public Employee GetEmployeeById(int id);
        public bool CreateEmployee(Employee employee);
        public bool UpdateEmployee(Employee employee);

        public bool DeleteEmployee(int id);

    }
}
