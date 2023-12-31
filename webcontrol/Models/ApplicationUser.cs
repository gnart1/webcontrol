﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace webcontrol.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
