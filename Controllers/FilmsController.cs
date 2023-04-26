using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PawKarTIWypozyczalnia.DAL;
using PawKarTIWypozyczalnia.Models;
using PawKarTIWypozyczalnia.ViewModels;
using System;
using System.IO;
using System.Linq;

namespace PawKarTIWypozyczalnia.Controllers
{
    public class FilmsController : Controller
    {
        FilmsContext db;
        IWebHostEnvironment env;

        public FilmsController(FilmsContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
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

        public IActionResult GetAllFilms()
        {
            var films = db.Films.OrderBy(f => f.Date);
            return View(films);
        }
        [HttpGet]
        public IActionResult AddFilm()
        {
            var model = new AddFilmViewModel();
            var categories = db.Kategorie.ToList();

            model.category = categories;

            return View(model);
        }
        [HttpPost]
        public IActionResult AddFilm(AddFilmViewModel model)
        {
            var folderPath = Path.Combine(env.WebRootPath, "content");
            var uniqueName = model.Poster.FileName + "_" + Guid.NewGuid().ToString();
            var posterPath = Path.Combine(folderPath, uniqueName);
            model.Poster.CopyTo(new FileStream(posterPath, FileMode.Create));
            model.newFilm.Date = DateTime.Now;
            model.newFilm.PosterName = uniqueName;
            db.Films.Add(model.newFilm);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult SearchFilms(string text) 
        {
            if (!String.IsNullOrEmpty(text)) 
            {
                var film = db.Films.Where(f => f.Title.Contains(text));
                return View(film.ToList());
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult EditFilm(int id)
        {
            var film = db.Films.Where(_ => _.Id == id).FirstOrDefault();

            return View(film);
        }
        [HttpPost]
        public IActionResult EditFilm(Film film)
        {
            var findFilm = db.Films.Where(f => f.Id == film.Id).FirstOrDefault();
            findFilm.Title = film.Title;
            findFilm.Director = film.Director;
            findFilm.Desc = film.Desc;
            findFilm.Price = film.Price;

            db.Entry(findFilm).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Details", "Films", new { filmId = findFilm.Id });
        }
    }
}
