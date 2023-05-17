using Microsoft.AspNetCore.Mvc;
using PawKarTIWypozyczalnia.DAL;
using PawKarTIWypozyczalnia.Infrastructure;
using PawKarTIWypozyczalnia.Models;
using PawKarTIWypozyczalnia.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PawKarTIWypozyczalnia.Controllers
{
    public class CartController : Controller
    {
        FilmsContext db;

        public CartController(FilmsContext db)
        {
            this.db = db;
        }

        [Route("Cart")]
        public IActionResult Index()
        {
            var cart = CartManager.GetItems(HttpContext.Session);
            ViewBag.totalPrice = CartManager.GetCartValue(HttpContext.Session);
            return View(cart);
        }

        public IActionResult AddToCart(int Id)
        {
            CartManager.AddToCart(HttpContext.Session,db,Id);
            return RedirectToAction("Index", "Cart");
        }
        [HttpPost]
        public IActionResult RemoveItem(int Id)
        {
            var model = new ItemRemoveViewModel()
            {
                ItemId = Id,
                ItemQuantity = CartManager.RemoveFromCart(HttpContext.Session,Id),
                TotalValue = CartManager.GetCartValue(HttpContext.Session),
                ItemValue = CartManager.GetCartValueItem(HttpContext.Session,Id)
            };
            return Json(model);
        }
    }
}
