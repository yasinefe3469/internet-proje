using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class OkulYonetimController : Controller
    {
        // GET: OkulYonetim
        WebOkulProjeEntities db = new WebOkulProjeEntities();

        public ActionResult Index(string p)
        {
            var degerler = from d in db.OkulYonetim select d;
            if(!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(o => o.AdSoyad.Contains(p));
            }
            return View(degerler.ToList());
            //var yonetim = db.OkulYonetim.ToList();
            //return View(yonetim);
        }

        [HttpGet]
        public ActionResult YoneticiEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YoneticiEkle(OkulYonetim oy)
        {
            db.OkulYonetim.Add(oy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YoneticiSil(int id)
        {
            var yonetici = db.OkulYonetim.Find(id);
            db.OkulYonetim.Remove(yonetici);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YoneticiGetir(int id)
        {
            var yonetim = db.OkulYonetim.Find(id);
            return View("YoneticiGetir", yonetim);
        }

        public ActionResult YoneticiGuncelle(OkulYonetim oy)
        {
            var yonetici = db.OkulYonetim.Find(oy.OkulYonetimID);
            yonetici.AdSoyad = oy.AdSoyad;
            yonetici.Gorevi = oy.Gorevi;
            db.SaveChanges();
            return RedirectToAction("Index");
                
        }
    }
}