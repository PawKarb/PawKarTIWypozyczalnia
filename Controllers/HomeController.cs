using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PawKarTIWypozyczalnia.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PawKarTIWypozyczalnia.Controllers
{
    public class HomeController : Controller
    {

        private FilmsContext db;

        public HomeController(FilmsContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var kategorie = db.Kategorie.ToList();
            return View(kategorie);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult StronyStatyczne(string name)
        {
            return View(name);
        }
    }
}
