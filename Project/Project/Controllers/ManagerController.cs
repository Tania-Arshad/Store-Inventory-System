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
        private Store_Inventory_SystemEntities db  = new Store_Inventory_SystemEntities();
        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.products = db.Products.ToList();
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
                ViewBag.products = db.Products.ToList();
                return View();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
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