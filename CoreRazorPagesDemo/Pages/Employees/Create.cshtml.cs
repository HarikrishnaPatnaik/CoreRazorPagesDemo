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
    public class CreateModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        
        [BindProperty]
        public Employee CreateEmployee { get; set; }

        public CreateModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;            
        }

        
        public ActionResult OnGet()
        {            
            return Page();
        }

        public ActionResult OnPostCreate()
        {            
            if (ModelState.IsValid)
            {
                try
                {
                    if (!_employeeRepository.EmployeeExists(CreateEmployee.Email))
                    {
                        bool result = _employeeRepository.CreateEmployee(CreateEmployee);
                        if (result)
                            return RedirectToPage("Index");
                        else
                            return Content("Failed to Create Employee.");
                    }
                }
                catch (Exception ex)
                {
                    return Content("Error while creating employee.");
                }
            }
            return Page();
        }
    }
}
