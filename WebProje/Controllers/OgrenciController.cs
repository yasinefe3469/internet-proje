using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci

        WebOkulProjeEntities db = new WebOkulProjeEntities();

        public ActionResult Index(string p)
        {
            var degerler = from d in db.Ogrenci select d;
            if(!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(o => o.OgrenciAdiSoyadi.Contains(p));
            }
            return View(degerler.ToList());
            //var ogrenciler = db.Ogrenci.ToList();
            //return View(ogrenciler);
        }

        [HttpGet]
        public ActionResult OgrenciEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OgrenciEkle(Ogrenci o)
        {
            db.Ogrenci.Add(o);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciSil(int id)
        {
            var ogrenci = db.Ogrenci.Find(id);
            db.Ogrenci.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciGetir(int id)
        {
            var ogr = db.Ogrenci.Find(id);
            return View("OgrenciGetir", ogr);
        }

        public ActionResult OgrenciGuncelle(Ogrenci o)
        {
            var ogrenci = db.Ogrenci.Find(o.OgrenciID);
            ogrenci.OgrenciAdiSoyadi = o.OgrenciAdiSoyadi;
            ogrenci.OgrenciNo = o.OgrenciNo;
            ogrenci.OgrenciDogumTarihi = o.OgrenciDogumTarihi;
            ogrenci.OgrenciKayitTarihi = o.OgrenciKayitTarihi;
            ogrenci.OgrenciBolumu = o.OgrenciBolumu;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}