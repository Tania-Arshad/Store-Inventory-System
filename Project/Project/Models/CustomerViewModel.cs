using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class CustomerViewModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int CNIC { get; set; }
        public string Email { get; set; }
        public int Contact_No { get; set; }
        public string Home_Address { get; set; }
    }
}
