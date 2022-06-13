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
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;

        [BindProperty]
        public Employee EditEmployee { get; set; }

        public EditModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ActionResult OnGet(int? data)
        {
            var isExists = _employeeRepository.EmployeeExists(data);            
            if (!isExists)
            {
                return NotFound();
            }

            EditEmployee = _employeeRepository.GetEmployee(data);

            if(EditEmployee == null)
            {
                return NotFound();
            }

            return Page();
        }

        public ActionResult OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isExists = _employeeRepository.EmployeeExists(EditEmployee.Id);
                    if (isExists)
                    {
                        var result = _employeeRepository.UpdateEmployee(EditEmployee);
                        if (result)
                            return RedirectToPage("Index");
                        else
                            return Content("Failed to Update Employee.");
                    }
                }
            }
            catch(Exception ex)
            {
                return Content("Error while Updating Employee.");
            }
            
            return Page();
        }
    }
}
