using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PawKarTIWypozyczalnia.DAL;
using System.Linq;

namespace PawKarTIWypozyczalnia.Controllers
{
    public class FilmsController : Controller
    {
        FilmsContext db;

        public FilmsController(FilmsContext db)
        {
            this.db = db;
        }

        public IActionResult FilmsList(string categoryName)
        {
            var category = db.Kategorie.Include("Films")
                .Where(c => c.Name.ToLower() == categoryName.ToLower())
                .Single();

            var films = category.Films.ToList();

            return View(films); 
        }
    }
}
