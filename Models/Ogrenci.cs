namespace MvcEf.Models
{
    public class Ogrenci : ModelBase
    {
        public string AdiSoyadi { get; set; }
        public string Adres { get; set; }

        public int OgrenciNo { get; set; }
        public DateTime KayitTarihi { get; set; }

        public List<Kurs> Kurslar { get; set; } = new List<Kurs>();
    }
}