using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sinif;
using PagedList;
using PagedList.Mvc;
namespace ProjeCV.Controllers
{
    public class HobilerController : Controller
    {
        // GET: Hobiler
        DbCvEntities db = new DbCvEntities();
        [Authorize(Users = "veysel.dogan@ogr.sakarya.edu.tr")]
        public ActionResult Index(int sayfa=1)
        {
           var degerler = db.TBLINTEREST.ToList().ToPagedList(sayfa,5);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniHobi()
        {
            return View();
        }



        [HttpPost]
        public ActionResult YeniHobi(TBLINTEREST p)
        {
            db.TBLINTEREST.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult HobiSil(int id)
        {
            var hobi = db.TBLINTEREST.Find(id);
            db.TBLINTEREST.Remove(hobi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        public ActionResult HobiGetir(int id)
        {
            var hobi = db.TBLINTEREST.Find(id);
            return View("HobiGetir", hobi);
        }
        public ActionResult Guncelle(TBLINTEREST p)
        {
            var veriler = db.TBLINTEREST.Find(p.ID);
            veriler.INTEREST = p.INTEREST;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
  