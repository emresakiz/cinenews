using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SinemaBilgi.Areas.Admin.Models;
using SinemaBilgi.Models;
namespace SinemaBilgi.Areas.Admin.Controllers
{
    public class UyelerController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var kullanicilar = new UserStore<ApplicationUser>(context);
            ViewBag.kullanicilar = kullanicilar.Users.ToList();
            return View();
        }
    }
}