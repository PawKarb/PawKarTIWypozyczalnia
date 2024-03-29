﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PawKarTIWypozyczalnia.DAL;

namespace PawKarTIWypozyczalnia.Migrations
{
    [DbContext(typeof(FilmsContext))]
    [Migration("20230301182845_add_data")]
    partial class add_data
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PawKarTIWypozyczalnia.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Desc")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KategoriaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KategoriaId");

                    b.ToTable("Films");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Desc = "20 sierpnia 1973 roku teksańska policja trafiła do stojącego na uboczu domu Thomasa Hewitta - byłego pracownika lokalnej rzeźni. Na miejscu odkryli rozkładające się zwłoki 33 osób, które zostały zamordowane przez psychopatycznego zabójcę noszącego na twarzy maskę z ludzkiej skóry i posługującego się piłą mechaniczną.",
                            Director = "Marcus Nispel",
                            KategoriaId = 1,
                            Price = 10m,
                            Title = "Teksańska Masakra Piłą Mechaniczną"
                        },
                        new
                        {
                            Id = 2,
                            Desc = "Mężczyzna dostaje obsesji na punkcie książki, która według niego opisuje i przewiduje jego życie i przyszłość.",
                            Director = "Joel Schumacher",
                            KategoriaId = 3,
                            Price = 14m,
                            Title = "Numer 23"
                        },
                        new
                        {
                            Id = 3,
                            Desc = "Uznany pisarz przenosi się na prowincję, by w spokoju tworzyć kolejne książki. Wkrótce odwiedzi go tajemniczy mężczyzna, który oskarży Raineya o plagiat.",
                            Director = "David Koepp",
                            KategoriaId = 3,
                            Price = 12m,
                            Title = "Sekretne Okno"
                        },
                        new
                        {
                            Id = 4,
                            Desc = "Podróż hobbita z Shire i jego ośmiu towarzyszy, której celem jest zniszczenie potężnego pierścienia pożądanego przez Czarnego Władcę - Saurona.",
                            Director = "Peter Jackson",
                            KategoriaId = 5,
                            Price = 20m,
                            Title = "Władca Pierścieni: Drużyna Pierścienia"
                        },
                        new
                        {
                            Id = 5,
                            Desc = "Emerytowani agenci specjalni CIA zostają wrobieni w zamach. By się ratować, muszą reaktywować stary zespół.",
                            Director = "Robert Schwentke",
                            KategoriaId = 4,
                            Price = 11m,
                            Title = "Red"
                        },
                        new
                        {
                            Id = 6,
                            Desc = "Dziennikarz śledczy rozmawia z dziewięcioma księżmi katolickimi, którzy dopuścili się zbrodni pedofilii i molestowania nieletnich, a także ich ofiarami.",
                            Director = "Tomasz Sekielski",
                            KategoriaId = 2,
                            Price = 0m,
                            Title = "Tylko nie mów nikomu"
                        },
                        new
                        {
                            Id = 7,
                            Desc = "Wiedeń u progu XX w. Syn rzemieślnika, iluzjonista Eisenheim, wykorzystuje niezwykłe umiejętności, by zdobyć miłość arystokratki, narzeczonej austro-węgierskiego księcia.",
                            Director = "Neil Burger",
                            KategoriaId = 5,
                            Price = 13m,
                            Title = "Iluzjonista"
                        },
                        new
                        {
                            Id = 8,
                            Desc = "Grupa osób budzi się w pełnym śmiertelnych pułapek sześcianie. Nieznajomi muszą zacząć współpracować ze sobą, by przeżyć.",
                            Director = "Vincenzo Natali",
                            KategoriaId = 3,
                            Price = 15m,
                            Title = "Cube"
                        },
                        new
                        {
                            Id = 9,
                            Desc = "Frank Cotton nabywa tajemniczą kostkę, za pomocą której można przywołać demony z piekła.",
                            Director = "Clive Barker",
                            KategoriaId = 1,
                            Price = 16m,
                            Title = "Hellraiser: Wysłannik Piekieł"
                        },
                        new
                        {
                            Id = 10,
                            Desc = "Seryjny morderca i inteligentna agentka łączą siły, by znaleźć przestępcę obdzierającego ze skóry swoje ofiary.",
                            Director = "Jonathan Demme",
                            KategoriaId = 3,
                            Price = 17m,
                            Title = "Milczenie Owiec"
                        });
                });

            modelBuilder.Entity("PawKarTIWypozyczalnia.Models.Kategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategorie");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Desc = "Straszne filmy",
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 2,
                            Desc = "Filmy oparte na faktach",
                            Name = "Dokumentalne"
                        },
                        new
                        {
                            Id = 3,
                            Desc = "Dreszczowce",
                            Name = "Thiller"
                        },
                        new
                        {
                            Id = 4,
                            Desc = "Filmy z akcją",
                            Name = "Sensacyjne"
                        },
                        new
                        {
                            Id = 5,
                            Desc = "Elementy magiczne i nadprzyrodzone",
                            Name = "Fantasy"
                        });
                });

            modelBuilder.Entity("PawKarTIWypozyczalnia.Models.Film", b =>
                {
                    b.HasOne("PawKarTIWypozyczalnia.Models.Kategoria", "Kategoria")
                        .WithMany("Films")
                        .HasForeignKey("KategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategoria");
                });

            modelBuilder.Entity("PawKarTIWypozyczalnia.Models.Kategoria", b =>
                {
                    b.Navigation("Films");
                });
#pragma warning restore 612, 618
        }
    }
}
