using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public System.DateTime Exp_Date { get; set; }
        public System.DateTime Mfg_Date { get; set; }
    }
}