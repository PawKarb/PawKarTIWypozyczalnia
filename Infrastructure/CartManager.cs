using Microsoft.AspNetCore.Http;
using PawKarTIWypozyczalnia.DAL;
using PawKarTIWypozyczalnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PawKarTIWypozyczalnia.Infrastructure
{
    public static class CartManager
    {

        public static void AddToCart(ISession session, FilmsContext db, int id) 
        {
            var cart = GetItems(session);
            var thisFilm = cart.Find(f => f.Film.Id == id);

            if (thisFilm != null)
            {
                thisFilm.Quantity++;
                thisFilm.Value += thisFilm.Film.Price;
            }
            else
            {
                var newCartItem = db.Films.Where(f => f.Id == id).FirstOrDefault();
                if (newCartItem != null) 
                {
                    var cartItem = new CartItem
                    {
                        Film = newCartItem,
                        Quantity = 1,
                        Value = newCartItem.Price
                    };
                    cart.Add(cartItem);
                }
            }
            SessionHelper.SetObjectAsJson(session, Consts.CartSessionKey, cart);
        }

        public static int RemoveFromCart(ISession session, int id)
        {
            var cart = GetItems(session);

            var thisFilm = cart.Find(i => i.Film.Id == id);
            var q = 0;

            if (thisFilm == null) return 0;

            if (thisFilm.Quantity > 1)
            {
                thisFilm.Quantity--;
                thisFilm.Value -= thisFilm.Film.Price;
                q = thisFilm.Quantity;
            }
            else 
            {
                cart.Remove(thisFilm);
            }
            session.SetObjectAsJson(Consts.CartSessionKey, cart);
            return q;
        }

        internal static decimal GetCartValue(ISession session)
        {
            var cart = GetItems(session);
            return cart.Sum(i => i.Value);
        }

        internal static decimal GetCartValueItem(ISession session, int id)
        {
            var cart = GetItems(session);
            foreach (var item in cart) 
            {
                if (id == item.Film.Id) 
                {
                    return cart.Sum(i => i.Value);
                }
            }
            return 0;
        }

        public static List<CartItem> GetItems(ISession session)
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(session, Consts.CartSessionKey);

            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            return cart;
        }
    }
}
