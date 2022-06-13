using CoreRazorPagesDemo.Data;
using CoreRazorPagesDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRazorPagesDemo.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public EmployeeRepository(EmployeeDbContext dbContext)
        {
            _employeeDbContext = dbContext;
        }

        public bool CreateEmployee(Employee employee)
        {
            _employeeDbContext.Employees.Add(employee);
            return Save();
        }

        public bool DeleteEmployee(Employee employee)
        {
            _employeeDbContext.Employees.Remove(employee);
            return Save();
        }

        public bool EmployeeExists(string email)
        {
            return _employeeDbContext.Employees.Any(emp => emp.Email == email);
        }

        public bool EmployeeExists(int? id)
        {
            return _employeeDbContext.Employees.Any(emp => emp.Id == id);
        }

        public Employee GetEmployee(int? employeeId)
        {
            return _employeeDbContext.Employees.FirstOrDefault(emp => emp.Id == employeeId);           
        }

        public ICollection<Employee> GetEmployees()
        {
            return _employeeDbContext.Employees.ToList();
        }

        public bool UpdateEmployee(Employee employee)
        {
            _employeeDbContext.Employees.Update(employee);
            return Save();
        }

        public bool Save()
        {
            return _employeeDbContext.SaveChanges() > 0 ? true : false;
        }

        
    }
}
