namespace minitheater.Models
{
    public class Reservasi
    {
        public int Id { get; set; }
        public int JadwalId { get; set; }
        public List<string> Kursi { get; set; } = new();
    }
}
