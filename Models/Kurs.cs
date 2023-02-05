namespace MvcEf.Models
{
    public class Kurs : ModelBase
    {
        public string GrupKodu { get; set; }
        public int Kapasite { get; set; }

        public int DersId { get; set; } //.net
        public Ders Ders { get; set; }

        public List<Ogrenci> Ogrenciler { get; set; } = new List<Ogrenci>();
    }
}