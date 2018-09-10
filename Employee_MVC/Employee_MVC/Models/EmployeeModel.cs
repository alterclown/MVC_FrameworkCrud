using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_MVC.Models
{
    public class EmployeeModel
    {
        public int Employee_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email_Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}