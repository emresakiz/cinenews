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

    public class RolYonetimiController : Controller
    {  
        ApplicationDbContext context = new ApplicationDbContext();
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var rolstore = new RoleStore<IdentityRole>(context);
            var rolmenager = new RoleManager<IdentityRole>(rolstore);

            var model = rolmenager.Roles.ToList();
            var kullanicilar = new UserStore<ApplicationUser>(context);
            ViewBag.kullanicilar = kullanicilar.Users.ToList();
            var roller = new RoleStore<IdentityRole>(context);
            ViewBag.roller = roller.Roles.ToList();
            return View(model);
        }

        public ActionResult RolEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RolEkle(RolEkleModel rol)
        {
            var rolstore = new RoleStore<IdentityRole>(context);
            var rolmenager = new RoleManager<IdentityRole>(rolstore);

            if (rolmenager.RoleExists(rol.RolAd) == false)
            {
                rolmenager.Create(new IdentityRole(rol.RolAd));
            }
            return RedirectToAction("Index");
        }

        public ActionResult RolKullaniciEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RolKullaniciEkle(RolKullaniciEkleModel model)
        {
            var rolstore = new RoleStore<IdentityRole>(context);
            var rolmenager = new RoleManager<IdentityRole>(rolstore);

            var userStore = new UserStore<ApplicationUser>(context);
            var userMenager = new UserManager<ApplicationUser>(userStore);

            var kullanici = userMenager.FindByName(model.KullaniciAdi);
            if (!userMenager.IsInRole(kullanici.Id, model.RolAdi))
                userMenager.AddToRole(kullanici.Id, model.RolAdi);

            return RedirectToAction("Index");
        }
    }
}