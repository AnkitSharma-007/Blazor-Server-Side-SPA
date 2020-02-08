using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServerSideSPA.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
