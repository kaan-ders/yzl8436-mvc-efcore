using Microsoft.AspNetCore.Mvc;
using MvcEf.Models;

namespace MvcEf.Controllers
{
    //öğrenci ekle, sil, güncelle ve listele
    public class OgrenciController : Controller
    {
        //öğrenci listeleme
        public IActionResult Index()
        {
            using (OkulContext context = new OkulContext())
            {
                //select * from Ogrenci where SilindiMi = 0
                List<Ogrenci> ogrenciler = context.Ogrenci.Where(o => o.SilindiMi == false).ToList();

                return View(ogrenciler);
            }
        }

        public IActionResult Detay(int id)
        {
            using (OkulContext context = new OkulContext())
            {
                //select top 1 from Ogrenci where Id = 2
                //var q = from item in context.Ogrenci where item.Id == id select item;

                Ogrenci ogrenci = context.Ogrenci.First(item => item.Id == id && item.SilindiMi == false);

                //foreach (var item in context.Ogrenci)
                //{
                //    if (item.Id == id && item.SilindiMi == false)
                //        return item;
                //}

                return View(ogrenci);
            }
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Ogrenci ogrenci)
        {
            //dbye kaydet
            using (OkulContext context = new OkulContext())
            {
                //insert into Ogrenci (AdiSoyadi, KayitTarihi,....) values ('Ahmet sada', '01.01.2022', ...)
                context.Ogrenci.Add(ogrenci);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}