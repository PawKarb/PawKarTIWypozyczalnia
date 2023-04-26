using Microsoft.AspNetCore.Mvc;
using PawKarTIWypozyczalnia.DAL;
using PawKarTIWypozyczalnia.Infrastructure;
using PawKarTIWypozyczalnia.Models;
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

        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, Consts.CartSessionKey);
            ViewBag.totalPrice = cart.Sum(i=>i.Value);
            return View(cart);
        }
        public IActionResult AddToCart(int Id) 
        {
            var film = db.Films.Find(Id);
            var session = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, Consts.CartSessionKey);
            if (session == null)
            {
                var cart = new List<CartItem>();
                cart.Add(new CartItem { Film = film, Quantity = 1, Value = film.Price });
                SessionHelper.SetObjectAsJson(HttpContext.Session, Consts.CartSessionKey, cart);
            }
            else 
            {
                var index = GetIndex(Id, session);
                if (index != -1)
                {
                    session[index].Quantity++;
                    session[index].Value += film.Price;
                }
                else 
                {
                    session.Add(new CartItem { Film = film, Quantity = 1, Value = film.Price });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, Consts.CartSessionKey, session);
            }
            return RedirectToAction("Index","Cart");
        }
        private int GetIndex(int Id, List<CartItem> cart) 
        {
            for (int i = 0; i < cart.Count;i++)
            {
                if (cart[i].Film.Id == Id)
                {

                    return i;
                }
            }
            return -1;
        }
    }
}
