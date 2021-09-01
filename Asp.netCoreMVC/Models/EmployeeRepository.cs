using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netCoreMVC.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        List<Employee> Data = new List<Employee>()
        {
            new Employee()
            { EmployeeId = 1, FirstName = "Neha", LastName = "K", Email = "Neha.k@gmail.com", Salary = 30000, Company = "Summit", Dept = "IT"
            },
            new Employee()
            { EmployeeId = 2, FirstName = "Nitin", LastName = "C", Email = "Nitin.C@gmail.com", Salary = 50000, Company = "IBM", Dept = "IT"
            },
            new Employee()
            { EmployeeId = 3, FirstName = "Madhu", LastName = "K", Email = "Madhu.K@gmail.com", Salary = 20000, Company = "HCl", Dept = "IT"
            },
            new Employee()
            { EmployeeId = 4, FirstName = "Ramesh", LastName = "MD", Email = "Ramesh.MD@gmail.com", Salary = 26700, Company = "Tech Mahindra", Dept = "BPO"
            },
            new Employee()
            { EmployeeId = 5, FirstName = "Chitra", LastName = "R", Email = "Chitra.R@gmail.com", Salary = 25000, Company = "Dell", Dept = "BPO"
            },
            new Employee()
            { EmployeeId = 6, FirstName = "Suresh", LastName = "K", Email = "Suresh.K@gmail.com", Salary = 24500, Company = "Infosys", Dept = "BPO"
            },
            new Employee()
            { EmployeeId = 7, FirstName = "Naina", LastName = "H", Email = "Naina.H@gmail.com", Salary = 30000, Company = "Summit", Dept = "IT"
            },
            new Employee()
            { EmployeeId = 8, FirstName = "Lokesh", LastName = "C", Email = "Lokesh.C@gmail.com", Salary = 90000, Company = "IBM", Dept = "IT"
            },
            new Employee()
            { EmployeeId = 9, FirstName = "John", LastName = "K", Email = "John.K@gmail.com", Salary = 20000, Company = "HCl", Dept = "IT"
            },
            new Employee()
            { EmployeeId = 10, FirstName = "Rajesh", LastName = "MD", Email = "Rajesh.MD@gmail.com", Salary = 26700, Company = "Tech Mahindra", Dept = "BPO"
            }

        };

        public List<Employee> getAllEmployee()
        {
            return Data;
        }

        public Employee GetEmployeeById(int id)
        {
            return Data.FirstOrDefault(a => a.EmployeeId == id);
        }

        public bool CreateEmployee(Employee employee)
        {
            try
            {
                
                var maxId = Data.Select(a => a.EmployeeId).Max();
                employee.EmployeeId = maxId + 1;
                Data.Add(employee);
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                var resultEmployee = GetEmployeeById(employee.EmployeeId);
                resultEmployee.FirstName = employee.FirstName;
                resultEmployee.LastName = employee.LastName;
                resultEmployee.Email = employee.Email;
                resultEmployee.Salary = employee.Salary;
                resultEmployee.Company = employee.Company;
                resultEmployee.Dept = employee.Dept;
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                Data.Remove(GetEmployeeById(id));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
