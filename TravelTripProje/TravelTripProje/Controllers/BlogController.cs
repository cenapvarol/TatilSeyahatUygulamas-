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
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            //var deger = context.Blogs.ToList();
            by.Deneme1 = context.Blogs.ToList();
            ViewBag.data = by.Deneme1;
            ViewBag.data1 = context.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            //ViewBag.data1 = by.Deneme1.Take(3);
            return View();
            //return View(by);
        }

        
        public ActionResult BlogDetay(int id)
        {
            //var deger = context.Blogs.Where(x => x.ID == id).ToList();
            by.Deneme1 = context.Blogs.Where(x => x.ID == id).ToList();
            by.Deneme2 = context.Yorumlars.Where(x => x.Blogid == id).ToList();
            return View(by);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar yrm)
        {
            
            context.Yorumlars.Add(yrm);
            context.SaveChanges();
            return PartialView();
        }
    }
}