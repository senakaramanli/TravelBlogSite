using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;
using PagedList;
using PagedList.Mvc;


namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            var degerler = c.Blogs.OrderByDescending(x=>x.ID).ToList().ToPagedList(sayfa, 5);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var b = c.Blogs.Find(id);
            return View("BlogGetir", b);
        }
     
        public ActionResult BlogGuncelle(Blog b)
        {

           var bl = c.Blogs.Find(b.ID);
            bl.Aciklama = b.Aciklama;
            bl.Baslik = b.Baslik;
            bl.BlogImage = b.BlogImage;
            bl.Tarih = b.Tarih;
            c.SaveChanges();
           return RedirectToAction("Index");
        }

        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        public ActionResult YorumGetir(int id)
        {
            var y = c.Yorumlars.Find(id);
            return View("YorumGetir", y);
        }

        public ActionResult YorumGuncelle(Yorumlar y)
        {

            var yorum = c.Yorumlars.Find(y.ID);
            yorum.Yorum = y.Yorum;
            yorum.KullaniciAdi = y.KullaniciAdi;
            yorum.Mail = y.Mail;           
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}