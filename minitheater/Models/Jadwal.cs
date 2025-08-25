namespace minitheater.Models
{
    public class Jadwal
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; } = null!;

        public DateTime Tanggal { get; set; }
        public string Jam { get; set; } = "";

        public List<Kursi> KursiList { get; set; } = new();
    }
}
