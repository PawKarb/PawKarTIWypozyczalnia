using Microsoft.AspNetCore.Http;
using PawKarTIWypozyczalnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PawKarTIWypozyczalnia.Infrastructure
{
    public static class CartManager
    {
        public static int RemoveFromCart(ISession session, int id)
        {
            var cart = GetItems(session);

            var thisFilm = cart.Find(i => i.Film.Id == id);
            var q = 0;

            if (thisFilm == null) return 0;

            if (thisFilm.Quantity > 1)
            {
                thisFilm.Quantity--;
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

        internal static decimal GetCartValueItem(ISession session)
        {
            var cart = GetItems(session);
            return 0;
        }

        private static List<CartItem> GetItems(ISession session)
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
