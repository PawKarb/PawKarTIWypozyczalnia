using Microsoft.AspNetCore.Http;
using PawKarTIWypozyczalnia.Models;
using System.Collections.Generic;

namespace PawKarTIWypozyczalnia.ViewModels
{
    public class AddFilmViewModel
    {
        public Film newFilm { get; set; }
        public List<Kategoria> category { get; set; }
        public IFormFile Poster { get; set; }
    }
}
