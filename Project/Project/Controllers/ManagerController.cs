using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class ManagerController : Controller
    {
        private Store_Inventory_SystemEntities1 db  = new Store_Inventory_SystemEntities1();
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(ProductViewModel obj)
        {
            try
            {
                Product C = new Product();
                C.Name = obj.Name;
                C.Price = obj.Price;
                C.Quantity = obj.Quantity;
                C.Exp_Date = DateTime.Now;
                C.Mfg_Date = DateTime.Now;
                db.Products.Add(C);
                db.SaveChanges();
                return View("Login");
            }
            catch(Exception ex) {
                return View("Login");
            }
        }
        public ActionResult UpdateProduct()
        {
            return View();
        }
        public ActionResult DeleteProduct()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}