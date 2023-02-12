using Microsoft.AspNetCore.Mvc;
using MvcEf.Models;

namespace MvcEf.Controllers
{
    //öğrenci ekle, sil, güncelle ve listele - crud
    public class OgrenciController : Controller
    {
        private OkulContext _context;

        public OgrenciController(OkulContext context)
        {
            _context = context;
        }

        #region Gosterme

        //öğrenci listeleme
        public IActionResult Index()
        {
            //select * from Ogrenci where SilindiMi = 0
            List<Ogrenci> ogrenciler = _context.Ogrenci.Where(o => o.SilindiMi == false).ToList();

            return View(ogrenciler);
        }

        public IActionResult Detay(int id)
        {
            //using (OkulContext context = new OkulContext())
            //{
                //select top 1 from Ogrenci where Id = 2
                //var q = from item in context.Ogrenci where item.Id == id select item;
                //linq

                Ogrenci ogrenci = _context.Ogrenci.First(item => item.Id == id && item.SilindiMi == false);

                //foreach (var item in context.Ogrenci)
                //{
                //    if (item.Id == id && item.SilindiMi == false)
                //        return item;
                //}

                return View(ogrenci);
            //}
        }

        #endregion

        #region Ekle

        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Ogrenci ogrenci)
        {
            //dbye kaydet
            //using (OkulContext context = new OkulContext())
            //{
                //insert into Ogrenci (AdiSoyadi, KayitTarihi,....) values ('Ahmet sada', '01.01.2022', ...)
                _context.Ogrenci.Add(ogrenci);
                _context.SaveChanges();

                return RedirectToAction("Index");
            //}
        }

        #endregion

        #region Guncelle

        [HttpGet]
        public IActionResult Guncelle(int id)
        {
            //using (OkulContext context = new OkulContext())
            //{
                //select top 1 * from Ogrenci where Id = 1
                var ogrenci = _context.Ogrenci.First(item => item.Id == id);

                return View(ogrenci);
            //}
        }

        [HttpPost]
        public IActionResult Guncelle(Ogrenci ogrenci)
        {
            //using (OkulContext context = new OkulContext())
            //{
                //update Ogrenci set AdiSoyadi = 'asdnkla', OgrenciNo = '12312' where Id = 2
                _context.Ogrenci.Update(ogrenci);
                _context.SaveChanges();

                return RedirectToAction("Index");
            //}
        }

        #endregion

        [HttpGet]
        public IActionResult Sil(int id)
        {
            //using (OkulContext context = new OkulContext())
            //{
                var ogrenci = _context.Ogrenci.First(x => x.Id == id);

                //fiziksel silme - hard delete
                //delete from Ogrenci where Id = 1
                //context.Ogrenci.Remove(ogrenci);

                //soft delete
                ogrenci.SilindiMi = true;
                _context.SaveChanges();

                return RedirectToAction("Index");
            //}
        }
    }
}