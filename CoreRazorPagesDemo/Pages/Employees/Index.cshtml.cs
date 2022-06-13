using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreRazorPagesDemo.Models;
using CoreRazorPagesDemo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreRazorPagesDemo.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;

        public IList<Employee> Employees = new List<Employee>();

        public IndexModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            Employees = _employeeRepository.GetEmployees().ToList();
        }

        public ActionResult OnGet()
        {
            return Page();
        }
    }
}
