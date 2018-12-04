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
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult SignIn()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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