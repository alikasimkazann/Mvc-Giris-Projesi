using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stok_Proje.Models.Entity;

namespace Stok_Proje.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(Tbl_Satislar p1)
        {
            db.Tbl_Satislar.Add(p1);
            db.SaveChanges();
            return View("Index");
        }
    }
}