using ShoppingCart.Models;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            ProductModel productModel = new ProductModel();
            ViewBag.products = productModel.FindAll();
            return View();
        }
    }
}
