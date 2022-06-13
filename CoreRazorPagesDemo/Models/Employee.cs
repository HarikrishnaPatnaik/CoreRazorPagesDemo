using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRazorPagesDemo.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is a required Field.")]
        [MaxLength(30,ErrorMessage = "First Name should not be more than 30 characters.")]
        [MinLength(3,ErrorMessage = "First Name length should be more than 3 characters.")]
        [Display(Name = "First Name")]
        [BindProperty]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is a required Field.")]
        [MaxLength(30, ErrorMessage = "Last Name should not be more than 30 characters.")]
        [MinLength(3, ErrorMessage = "Last Name length should be more than 3 characters.")]
        [Display(Name = "Last Name")]
        [BindProperty]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Address is a required Field.")]
        [MaxLength(100, ErrorMessage = "Email Address should not be more than 100 characters.")]
        [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Invalid Email Address.")]
        [Display(Name = "Email Address")]
        [BindProperty]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gender is a required Field.")]
        [MaxLength(20, ErrorMessage = "Gender should not be more than 20 characters.")]
        [BindProperty]
        public string Gender { get; set; }

        [Required(ErrorMessage ="Salary is required field.")]
        [BindProperty]
        public decimal Salary { get; set; }
    }
}
