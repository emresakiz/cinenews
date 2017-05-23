using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SinemaBilgi.Models;

namespace SinemaBilgi.Controllers
{
    public class HomeController : Controller
    {
        SinemaBilgiModelEntities db = new SinemaBilgiModelEntities();
       
        public ActionResult Index()
        {
            ViewBag.a = db.Haberler.ToList();
            ViewBag.c = db.Slider.ToList();
            ViewBag.hf = db.Filmler.ToList();
            ViewBag.yk = db.Filmler.ToList();
            ViewBag.vz = db.Filmler.ToList();
            return View(db.Filmler.ToList());
        }

        public ActionResult Vizyonda()
        {
            ViewBag.hf = db.Filmler.ToList();
            ViewBag.yk = db.Filmler.ToList();
            ViewBag.vz = db.Filmler.ToList();
            return View(db.Filmler.ToList());
        }

        public ActionResult Fragmanlar()
        {
            ViewBag.hf = db.Filmler.ToList();
            ViewBag.yk = db.Filmler.ToList();
            ViewBag.vz = db.Filmler.ToList();
            return View(db.Filmler.ToList());
        }

        public ActionResult Yakinda()
        {
            ViewBag.hf = db.Filmler.ToList();
            ViewBag.yk = db.Filmler.ToList();
            ViewBag.vz = db.Filmler.ToList();
            return View(db.Filmler.ToList());
        }

        public ActionResult Haberler()
        {
            ViewBag.hf = db.Filmler.ToList();
            ViewBag.yk = db.Filmler.ToList();
            ViewBag.vz = db.Filmler.ToList();
            ViewBag.a = db.Haberler.ToList();
            return View(db.Filmler.ToList());
        }

    }
}