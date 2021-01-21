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
    public class YetenekController : Controller
    {
        // GET: Yetenek
        DbCvEntities db = new DbCvEntities();
        [Authorize(Users = "veysel.dogan@ogr.sakarya.edu.tr")]
        public ActionResult Index(int sayfa=1)
        {
           // Class1 cs = new Class1();
            var degerler = db.TBLSKILLS.ToList().ToPagedList(sayfa, 8);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TBLSKILLS p)
        {
            db.TBLSKILLS.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            var yetenek = db.TBLSKILLS.Find(id);
            db.TBLSKILLS.Remove(yetenek);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult YetenekGetir(int id)
        {
            var yetenek = db.TBLSKILLS.Find(id);
            return View("YetenekGetir", yetenek);
        }
        public ActionResult Guncelle(TBLSKILLS p)
        {
            var veriler = db.TBLSKILLS.Find(p.ID);
            veriler.SKILL = p.SKILL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}