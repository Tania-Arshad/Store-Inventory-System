using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private Store_Inventory_SystemEntities db = new Store_Inventory_SystemEntities();


       
        
        [HttpGet]    
        public ActionResult Index()
        {
            ViewBag.products = db.Products.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Login()
        {
            //ViewBag.customers = db.Customers.ToList();
            return View();
        }


        [HttpPost]
        public ActionResult LogIn(CustomerViewModel obj)
        {
            try
            {
                Customer C = new Customer();
                C.Name = obj.Name;
                C.Password = obj.Password;
                db.Customers.Add(C);
                db.SaveChanges();
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
        [HttpGet]
        public ActionResult SignIn()
        {
            //ViewBag.Customers = db.Customers.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(CustomerViewModel obj)
        {
            try
            {
                Customer C = new Customer();
                C.Name = obj.Name;
                C.Password = obj.Password;
                C.CNIC = obj.CNIC;
                C.Email = obj.Email;
                C.Contact_No = obj.Contact_No;
                C.Home_Address = obj.Home_Address;
                db.Customers.Add(C);
                db.SaveChanges();
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

        public ActionResult CheckOut()
        {
            ViewBag.products = db.Products.ToList();
            var all = from c in db.Add_To_Cart select c;
            db.Add_To_Cart.RemoveRange(all);
            db.SaveChanges();
            return View("Index");
        }
        public ActionResult Cart(int id)
        {
            Add_To_Cart C = new Add_To_Cart();
            Product P = db.Products.Find(id);
            C.Name = P.Name;
            C.Price = P.Price;
            C.Quantity = 1;
            C.Total = 100;
            db.Add_To_Cart.Add(C);
            db.SaveChanges();
            ViewBag.Cart = db.Add_To_Cart.ToList();
            return View();
        }
    }
}