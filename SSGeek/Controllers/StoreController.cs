using SSGeek.DAL;
using SSGeek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSGeek.Controllers
{
    public class StoreController : Controller
    {
        IProductDAL dal;
        public StoreController(IProductDAL dal)
        {
            this.dal = dal;
        }

        // GET: Store
        public ActionResult Index()
        {
            var products = dal.GetProducts();

            return View("Index", products);
        }

        public ActionResult ItemPage(int id)
        {
            Product product = dal.GetProduct(id);
            return View("ItemPage", product);
        }
        
        [HttpPost]
        public ActionResult AddToCart(int id, int quantity)
        {
            var product = dal.GetProduct(id);

            ShoppingCart cart = GetActiveShoppingCart();

            cart.AddToCart(product, quantity);

            return RedirectToAction("ItemCartPage");

        }



        private ShoppingCart GetActiveShoppingCart()
        {
            ShoppingCart cart = null;

            if(Session["Shopping_Cart"] == null)
            {
                cart = new ShoppingCart();
                Session["Shopping_Cart"] = cart;
            }
            else
            {
                cart = Session["Shopping_Cart"] as ShoppingCart;
            }

            return cart;
        }



        public ActionResult ItemCartPage()
        {
            ShoppingCart cart = GetActiveShoppingCart();

            return View(cart);
        }






    }
}