using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var deger = c.Blogs.ToList();
            return View(deger);
        }
        

        public ActionResult Sil(int id)
        {
            

            var deger = c.Blogs.Find(id);

            c.Blogs.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniBlok()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlok(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();

            return RedirectToAction("Index");
                
        }
        [HttpGet]
         public ActionResult BlokGuncelle(int id)
        {
            var deger = c.Blogs.Find(id);
            return View("BlokGuncelle", deger);
        }

        [HttpPost]
        public ActionResult BlokGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Baslik = b.Baslik;
            blg.Aciklama = b.Aciklama;
            blg.BlogImage = b.BlogImage;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Yorumlar()
        {
            var degerler = c.Yorumlars.ToList();
            return View(degerler);
        }

        public ActionResult YorumSil(int id)
        {
            var deger = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Yorumlar");
        }

        [HttpGet]
        public ActionResult YorumGuncelle(int id)
        {
            var deger = c.Yorumlars.Find(id);
            return View(deger);
        }

        [HttpPost]
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.ID);
            yrm.Kullanici = y.Kullanici;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("Yorumlar");
        }

    }
}