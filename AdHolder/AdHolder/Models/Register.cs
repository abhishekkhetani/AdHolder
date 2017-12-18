using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdHolder.Models
{
    public class Register
    {
        [Key]
        public int RegisterId { get; set; }
        
        [Required (ErrorMessage="Please Enter First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Please Enter Proper Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Select Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter Phone") ]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Please enter Proper phone number.")]
        public string Phone { get; set; }

        public bool isAdmin { get; set; }
    }
}