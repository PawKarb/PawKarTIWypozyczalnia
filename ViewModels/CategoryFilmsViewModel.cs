using PawKarTIWypozyczalnia.Models;
using System.Collections.Generic;

namespace PawKarTIWypozyczalnia.ViewModels
{
    public class CategoryFilmsViewModel
    {
        public IEnumerable<Film> CategoryFilms { get; set; }

        public IEnumerable<Film> RecentFilms { get; set; }

        public Kategoria Category { get; set; }
    }
}
