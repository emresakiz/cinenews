using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SinemaBilgi.Models;
namespace SinemaBilgi.Controllers
{
    public class FilmlerController : Controller
    {
        SinemaBilgiModelEntities db = new SinemaBilgiModelEntities();
        public ActionResult Index(int parametre)
        {
            ViewBag.id = parametre;
            return View(db.Filmler.ToList());
        }
    }
}