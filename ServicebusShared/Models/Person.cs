﻿ 
using System.ComponentModel.DataAnnotations;
 

namespace ServicebusShared.Models
{
    public class Person
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
    }
}
