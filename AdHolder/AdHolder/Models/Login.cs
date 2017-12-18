﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdHolder.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Please Enter Proper Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]        
        public string Password { get; set; }
    }
}