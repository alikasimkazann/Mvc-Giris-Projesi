using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stok_Proje.Models.Entity;

namespace Stok_Proje.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Urunler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.Tbl_Kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Tbl_Urunler p1)
        {
            var ktg = db.Tbl_Kategoriler.Where(x => x.KATEGORIID == p1.Tbl_Kategoriler.KATEGORIID).FirstOrDefault();
            p1.Tbl_Kategoriler = ktg;
            db.Tbl_Urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var urun = db.Tbl_Urunler.Find(id);
            db.Tbl_Urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> degerler = (from i in db.Tbl_Kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            var urn = db.Tbl_Urunler.Find(id);
            return View("UrunGetir", urn);
        }

        public ActionResult Guncelle(Tbl_Urunler p1)
        {
            var urn = db.Tbl_Urunler.Find(p1.URUNID);
           // urn.URUNID = p1.URUNID;
            urn.URUNAD = p1.URUNAD;
            urn.MARKA = p1.MARKA;
            var ktg = db.Tbl_Kategoriler.Where(x => x.KATEGORIID == p1.Tbl_Kategoriler.KATEGORIID).FirstOrDefault();
            urn.URUNKATEGORI= ktg.KATEGORIID;
            urn.FIYAT = p1.FIYAT;
            urn.STOK = p1.STOK;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}