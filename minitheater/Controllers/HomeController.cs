using Microsoft.AspNetCore.Mvc;
using minitheater.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace minitheater.Controllers
{
    public class HomeController : Controller
    {
        private static List<Film> _films = new()
        {
            new Film { Id = 1, Judul = "SORE - Istri Kamu Dari Masa Depan", Deskripsi = "Film romantis + sci-fi", Poster = "/images/sore.jpg" },
            new Film { Id = 2, Judul = "Merah Putih One For All", Deskripsi = "Film aksi perjuangan", Poster = "/images/merahputih.jpg" },
            new Film { Id = 3, Judul = "Demon Slayer", Deskripsi = "Anime action penuh visual keren", Poster = "/images/demon.jpg" }
        };

        private static List<Jadwal> _jadwals = new()
        {
            new Jadwal { Id = 1, FilmId = 1, Tanggal = DateTime.Today, Jam = "14:00" },
            new Jadwal { Id = 2, FilmId = 1, Tanggal = DateTime.Today, Jam = "19:00" },
            new Jadwal { Id = 3, FilmId = 2, Tanggal = DateTime.Today, Jam = "16:00" },
            new Jadwal { Id = 4, FilmId = 2, Tanggal = DateTime.Today, Jam = "20:30" },
            new Jadwal { Id = 5, FilmId = 3, Tanggal = DateTime.Today, Jam = "13:30" },
            new Jadwal { Id = 6, FilmId = 3, Tanggal = DateTime.Today, Jam = "18:15" }
        };

        public IActionResult Index()
        {
            return View(_films);
        }

        public IActionResult Jadwal(int id)
        {
            var film = _films.FirstOrDefault(f => f.Id == id);
            var jadwal = _jadwals.Where(j => j.FilmId == id).ToList();

            foreach (var j in jadwal)
            {
                j.Film = film; // assign Film object supaya @Model.Film.Judul tidak null
                if (!j.KursiList.Any())
                {
                    for (char row = 'A'; row <= 'E'; row++)
                        for (int col = 1; col <= 5; col++)
                            j.KursiList.Add(new Kursi { Nomor = $"{row}{col}", Status = false });
                }
            }

            ViewBag.Film = film;
            return View(jadwal);
        }

    }
}
