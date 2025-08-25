using Microsoft.AspNetCore.Mvc;
using minitheater.Models;
using System.Collections.Generic;
using System.Linq;

namespace minitheater.Controllers
{
    public class BookingController : Controller
    {
        private static List<Jadwal> _allJadwal => HomeControllerReflection.GetJadwals();

        public IActionResult Kursi(int jadwalId)
        {
            var jadwal = _allJadwal.FirstOrDefault(j => j.Id == jadwalId);
            if (jadwal == null) return NotFound();

            return View(jadwal);
        }

        [HttpPost]
        public IActionResult Reservasi(int jadwalId, List<string> selectedSeats)
        {
            var jadwal = _allJadwal.FirstOrDefault(j => j.Id == jadwalId);
            if (jadwal == null) return NotFound();

            // Tandai kursi terpilih
            foreach (var kursi in jadwal.KursiList)
                if (selectedSeats.Contains(kursi.Nomor))
                    kursi.Status = true;

            var reservasi = new Reservasi
            {
                JadwalId = jadwalId,
                Kursi = selectedSeats
            };

            return View(reservasi);
        }
    }

    // Helper supaya BookingController bisa akses jadwal HomeController
    public static class HomeControllerReflection
    {
        public static List<Jadwal> GetJadwals()
        {
            var type = typeof(HomeController);
            var field = type.GetField("_jadwals", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            return field?.GetValue(null) as List<Jadwal> ?? new List<Jadwal>();
        }
    }
}
