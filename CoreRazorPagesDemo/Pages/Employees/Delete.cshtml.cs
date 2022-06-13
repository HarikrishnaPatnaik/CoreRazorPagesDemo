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
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;

        [BindProperty]
        public Employee DeleteEmployee { get; set; }

        public DeleteModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ActionResult OnGet(int? id)
        {
            bool isExists = _employeeRepository.EmployeeExists(id);
            if (!isExists)
                return NotFound();

            DeleteEmployee = _employeeRepository.GetEmployee(id);            

            if (DeleteEmployee == null)
                return NotFound();

            ViewData["EmpID"] = DeleteEmployee.Id;            

            return Page();
        }

        public ActionResult OnPost()
        {
            try
            {
                bool isExists = _employeeRepository.EmployeeExists(DeleteEmployee.Id);
                if (!isExists)
                    return NotFound();

                bool result = _employeeRepository.DeleteEmployee(DeleteEmployee);

                if (!result)
                    return RedirectToPage("/Error");
            }
            catch(Exception ex)
            {
               ModelState.AddModelError("DeleteError", "Error occurred while deleting the employee",);
            }            

            return Page();
        }

        //public ActionResult OnPost(int? Id)
        //{
        //    bool isExists = _employeeRepository.EmployeeExists(Id);
        //    if (!isExists)
        //        return NotFound();
        //    DeleteEmployee = _employeeRepository.GetEmployee(Id);
        //    bool result = _employeeRepository.DeleteEmployee(DeleteEmployee);
        //    if (!result)
        //        return RedirectToPage("/Error");

        //    return Page();
        //}
    }
}
