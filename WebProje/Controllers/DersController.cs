using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class DersController : Controller
    {
        // GET: Ders

        WebOkulProjeEntities db = new WebOkulProjeEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.Ders select d;
            if(!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(o => o.DersAdi.Contains(p));
            }
            return View(degerler.ToList());
            //var dersler = db.Ders.ToList();
            //return View(dersler);
        }
        [HttpGet]
        public ActionResult DersEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DersEkle(Ders d)
        {
            var db = new WebOkulProjeEntities();
            db.Ders.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersSil(int id)
        {
            var ders = db.Ders.Find(id);
            db.Ders.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir(int id)
        {
            var ders = db.Ders.Find(id);
            return View("DersGetir", ders);
        }
        public ActionResult DersGuncelle(Ders d)
        {
            var ders = db.Ders.Find(d.DersID);
            ders.DersAdi = d.DersAdi;
            ders.DersKredisi = d.DersKredisi;
            ders.OkulYonetim.AdSoyad = d.OkulYonetim.AdSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}