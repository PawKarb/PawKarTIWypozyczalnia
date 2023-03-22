using System;
using System.ComponentModel.DataAnnotations;

namespace PawKarTIWypozyczalnia.Models
{
    public class Film
    {
       
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Director { get; set; }

        [StringLength(500)]
        public string Desc { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }

        public int KategoriaId { get; set; }

        public Kategoria Kategoria { get; set; }

    }
}
