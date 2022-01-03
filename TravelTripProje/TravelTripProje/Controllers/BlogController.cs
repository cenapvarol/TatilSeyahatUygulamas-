using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog


        Context context = new Context();
        public ActionResult Index()
        {
            var deger = context.Blogs.ToList();
            return View(deger);
        }

        BlogYorum by = new BlogYorum();
        public ActionResult BlogDetay(int id)
        {
            //var deger = context.Blogs.Where(x => x.ID == id).ToList();
            by.Deneme1 = context.Blogs.Where(x => x.ID == id).ToList();
            by.Deneme2 = context.Yorumlars.Where(x => x.Blogid == id).ToList();
            return View(by);
        }
    }
}