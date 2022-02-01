using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            CheckCartStatus();
            return View();
        }

        public void CheckCartStatus()
        {
            if (Session["cart"] == null)
            {
                Cart cart = new Cart();

                cart.Items = new List<Item>();
                cart.DiscountMultiplier = 1;

                Session["cart"] = cart;
            }
        }

        public ActionResult AddToCart(string id, int quantity)
        {
            ProductModel productModel = new ProductModel();

            if (quantity < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            CheckCartStatus();

            Cart cart = (Cart)Session["cart"];
            int index = FindCartProduct(id);

            if (index != -1)
            {
                // increment number of this product
                cart.Items[index].Quantity += quantity;
            }
            else
            {
                // add this product
                cart.Items.Add(new Item { Product = productModel.Find(id), Quantity = quantity });
            }

            // overwrite cart
            Session["cart"] = cart;

            return RedirectToAction("Index");
        }

        public ActionResult Remove(string id)
        {
            Cart cart = (Cart)Session["cart"];
            int index = FindCartProduct(id);
            cart.Items.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddDiscountCode(string code)
        {
            Cart cart = (Cart)Session["cart"];
            int discount = Int32.Parse(Regex.Match(code, @"\d+").Value);
            cart.Discount = discount;
            cart.DiscountMultiplier = (double)(100 - discount) / 100;
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

        private int FindCartProduct(string id)
        {
            List<Item> items = ((Cart)Session["cart"]).Items;

            for (int i = 0; i < items.Count; i++)
                if (items[i].Product.Id.Equals(id))
                    return i;
            return -1;
        }
    }
}
