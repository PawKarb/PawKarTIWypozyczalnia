using System.Collections;
using System.Collections.Generic;

namespace PawKarTIWypozyczalnia.Models
{
    public class Kategoria
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public ICollection<Film> Films { get; set; }

    }
}
