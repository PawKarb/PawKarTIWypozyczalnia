using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PawKarTIWypozyczalnia.DAL;
using PawKarTIWypozyczalnia.ViewModels;
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
            var model = new CategoryFilmsViewModel();
            var category = db.Kategorie.Include("Films")
                .Where(c => c.Name.ToLower() == categoryName.ToLower())
                .Single();

            var films = category.Films.ToList();

            model.CategoryFilms = films;
            model.RecentFilms = db.Films.OrderByDescending(f => f.Date).Take(3);
            model.Category = category;

            return View(model); 
        }

        public IActionResult Details(int filmId) 
        {
            var film = db.Films.Find(filmId);
            var category = db.Kategorie.Find(film.KategoriaId);

            return View(film);        
        }
    }
}
