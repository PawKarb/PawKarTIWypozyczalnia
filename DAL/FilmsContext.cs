using Microsoft.EntityFrameworkCore;
using PawKarTIWypozyczalnia.Models;

namespace PawKarTIWypozyczalnia.DAL
{
    public class FilmsContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Kategoria> Kategorie { get; set; }

        public FilmsContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategoria>().HasData(
                    new Kategoria() { Id = 1, Name = "Horror", Desc = "Straszne filmy"},
                    new Kategoria() { Id = 2, Name = "Dokumentalne", Desc = "Filmy oparte na faktach" },
                    new Kategoria() { Id = 3, Name = "Thiller", Desc = "Dreszczowce" },
                    new Kategoria() { Id = 4, Name = "Sensacyjne", Desc = "Filmy z akcją" },
                    new Kategoria() { Id = 5, Name = "Fantasy", Desc = "Elementy magiczne i nadprzyrodzone" }
                );
            modelBuilder.Entity<Film>().HasData(
                  new Film()
                  {
                      Id = 1,
                      KategoriaId = 1,
                      Title = "Teksańska Masakra Piłą Mechaniczną",
                      Director = "Marcus Nispel",
                      Desc = "20 sierpnia 1973 roku teksańska policja trafiła do stojącego na uboczu domu Thomasa Hewitta - byłego pracownika lokalnej rzeźni. Na miejscu odkryli rozkładające się zwłoki 33 osób, które zostały zamordowane przez psychopatycznego zabójcę noszącego na twarzy maskę z ludzkiej skóry i posługującego się piłą mechaniczną.",
                      Price = 10m,
                      Date = new System.DateTime(1967,5,23)
                  },
                new Film()
                {
                    Id = 2,
                    KategoriaId = 3,
                    Title = "Numer 23",
                    Director = "Joel Schumacher",
                    Desc = "Mężczyzna dostaje obsesji na punkcie książki, która według niego opisuje i przewiduje jego życie i przyszłość.",
                    Price = 14m,
                    Date = new System.DateTime(1999, 2, 11)
                },
                new Film()
                {
                    Id = 3,
                    KategoriaId = 3,
                    Title = "Sekretne Okno",
                    Director = "David Koepp",
                    Desc = "Uznany pisarz przenosi się na prowincję, by w spokoju tworzyć kolejne książki. Wkrótce odwiedzi go tajemniczy mężczyzna, który oskarży Raineya o plagiat.",
                    Price = 12m,
                    Date = new System.DateTime(2000, 8, 30)
                },
                new Film()
                {
                    Id = 4,
                    KategoriaId = 5,
                    Title = "Władca Pierścieni: Drużyna Pierścienia",
                    Director = "Peter Jackson",
                    Desc = "Podróż hobbita z Shire i jego ośmiu towarzyszy, której celem jest zniszczenie potężnego pierścienia pożądanego przez Czarnego Władcę - Saurona.",
                    Price = 20m,
                    Date = new System.DateTime(2006, 6, 2)
                },
                new Film()
                {
                    Id = 5,
                    KategoriaId = 4,
                    Title = "Red",
                    Director = "Robert Schwentke",
                    Desc = "Emerytowani agenci specjalni CIA zostają wrobieni w zamach. By się ratować, muszą reaktywować stary zespół.",
                    Price = 11m,
                    Date = new System.DateTime(1998, 5, 10)
                },
                new Film()
                {
                    Id = 6,
                    KategoriaId = 2,
                    Title = "Tylko nie mów nikomu",
                    Director = "Tomasz Sekielski",
                    Desc = "Dziennikarz śledczy rozmawia z dziewięcioma księżmi katolickimi, którzy dopuścili się zbrodni pedofilii i molestowania nieletnich, a także ich ofiarami.",
                    Price = 0m,
                    Date = new System.DateTime(2002, 7, 11)
                },
                new Film()
                {
                    Id = 7,
                    KategoriaId = 5,
                    Title = "Iluzjonista",
                    Director = "Neil Burger",
                    Desc = "Wiedeń u progu XX w. Syn rzemieślnika, iluzjonista Eisenheim, wykorzystuje niezwykłe umiejętności, by zdobyć miłość arystokratki, narzeczonej austro-węgierskiego księcia.",
                    Price = 13m,
                    Date = new System.DateTime(2010, 8, 1)
                },
                new Film()
                {
                    Id = 8,
                    KategoriaId = 3,
                    Title = "Cube",
                    Director = "Vincenzo Natali",
                    Desc = "Grupa osób budzi się w pełnym śmiertelnych pułapek sześcianie. Nieznajomi muszą zacząć współpracować ze sobą, by przeżyć.",
                    Price = 15m,
                    Date = new System.DateTime(2018,4,20)
                },
                new Film()
                {
                    Id = 9,
                    KategoriaId = 1,
                    Title = "Hellraiser: Wysłannik Piekieł",
                    Director = "Clive Barker",
                    Desc = "Frank Cotton nabywa tajemniczą kostkę, za pomocą której można przywołać demony z piekła.",
                    Price = 16m,
                    Date = new System.DateTime(2006, 2, 16)
                },
                new Film()
                {
                    Id = 10,
                    KategoriaId = 3,
                    Title = "Milczenie Owiec",
                    Director = "Jonathan Demme",
                    Desc = "Seryjny morderca i inteligentna agentka łączą siły, by znaleźć przestępcę obdzierającego ze skóry swoje ofiary.",
                    Price = 17m,
                    Date = new System.DateTime(2017, 6, 23)
                }
                );
        }
    }
}
