using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sinif;
namespace ProjeCV.Controllers
{
    public class KonferansController : Controller
    {
        // GET: Konferans
        DbCvEntities db = new DbCvEntities();
        [Authorize(Users = "veysel.dogan@ogr.sakarya.edu.tr")]
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TBLAWARDS select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.AWARD.Contains(p));
            }
           // Class1 cs = new Class1();
           // cs.Deger6 = db.TBLAWARDS.ToList();
            return View(degerler.ToList());
        }
        [HttpGet]
        public ActionResult YeniKonferans()
        {
            return View();
        }



        [HttpPost]
        public ActionResult YeniKonferans(TBLAWARDS p)
        {
            db.TBLAWARDS.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KonferansSil(int id)
        {
            var konferans = db.TBLAWARDS.Find(id);
            db.TBLAWARDS.Remove(konferans);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        public ActionResult KonferansGetir(int id)
        {
            var konferans = db.TBLAWARDS.Find(id);
            return View("KonferansGetir", konferans);
        }
        public ActionResult Guncelle(TBLAWARDS p)
        {
            var veriler = db.TBLAWARDS.Find(p.ID);
            veriler.AWARD = p.AWARD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}