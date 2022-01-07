using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class AnasayfaController : Controller
    {
        // GET: Anasayfa
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            

            return View(degerler);
        }

        public PartialViewResult Partial1()
        {
            ViewBag.data = c.Blogs.OrderByDescending(x => x.ID).ToList().Take(2);


            return PartialView();
        }

        public PartialViewResult Partial2()
        {
            var deger = c.Blogs.Where(x => x.ID == 3).ToList();
            return PartialView(deger);
        }
        
        public PartialViewResult Partial3()
        {
            var deger = c.Blogs.ToList();
            return PartialView(deger);
        }

        public PartialViewResult Partial4()
        {
            var deger = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial5()
        {
            var deger = c.Blogs.Where(x => x.ID < 5).ToList();
            return PartialView(deger);
        }
    }


}