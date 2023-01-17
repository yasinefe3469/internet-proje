using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class OgrenciDersController : Controller
    {
        // GET: OgrenciDers

        WebOkulProjeEntities db = new WebOkulProjeEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.OgrenciDers select d;
            if(!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(o => o.Ders.DersAdi.Contains(p));
            }
            return View(degerler.ToList());
            //var ogrd = db.OgrenciDers.ToList();
            //return View(ogrd);
        }

        [HttpGet]
        public ActionResult OgrenciDersEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OgrenciDersEkle(OgrenciDers ogrd)
        {
            var db = new WebOkulProjeEntities();
            db.OgrenciDers.Add(ogrd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciDersSil(int id)
        {
            var ogrders = db.OgrenciDers.Find(id);
            db.OgrenciDers.Remove(ogrders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciDersGetir(int id)
        {
            var ogrders = db.OgrenciDers.Find(id);
            return View("OgrenciDersGetir", ogrders);
        }
        public ActionResult OgrenciDersiGuncelle(OgrenciDers ogrd)
        {
            var ogr = db.OgrenciDers.Find(ogrd.ID);
            ogr.Ders.DersAdi = ogrd.Ders.DersAdi;
            ogr.Ogrenci.OgrenciAdiSoyadi = ogrd.Ogrenci.OgrenciAdiSoyadi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}