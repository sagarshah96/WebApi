using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebApi.Models
{
    public class EmpModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Designation { get; set; }
    }
}