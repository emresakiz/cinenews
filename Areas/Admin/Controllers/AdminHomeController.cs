using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SinemaBilgi.Models;
using System.IO;

namespace SinemaBilgi.Areas.Admin.Controllers
{   [Authorize(Roles = "Admin")]
    public class AdminHomeController : Controller
    {
        SinemaBilgiModelEntities db = new SinemaBilgiModelEntities();
        

        // GET: Admin/Filmler
        public async Task<ActionResult> Index()
        {
            return View(await db.Filmler.ToListAsync());
        }

        // GET: Admin/Filmler/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filmler filmler = await db.Filmler.FindAsync(id);
            if (filmler == null)
            {
                return HttpNotFound();
            }
            return View(filmler);
        }

        // GET: Admin/Filmler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Filmler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FilmID,FilmAd,FilmImg,FragmanUrl,FilmKategori,Yapimi,Turu,Suresi,Yonetmeni,Oyuncular,Senaryo,Yapimci,Ozeti,VizyonTarihi")] Filmler filmler, HttpPostedFileBase FilmImg)
        {
            if (ModelState.IsValid)
            {
                if (FilmImg != null && FilmImg.ContentLength > 0)
                {
                var fileName = Path.GetFileName(FilmImg.FileName);
                fileName = Guid.NewGuid().ToString() + ".jpg";
                fileName = fileName.Replace("-", "");
                filmler.FilmImg = "/Content/p/" + fileName;
                var path = Path.Combine(Server.MapPath("~/Content/p"), fileName);
                FilmImg.SaveAs(path);
                }
                
                db.Filmler.Add(filmler);
                await  db.SaveChangesAsync();
               
                return RedirectToAction("Index");
            }

            return View(filmler);
        }

        // GET: Admin/Filmler/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filmler filmler = await db.Filmler.FindAsync(id);
            if (filmler == null)
            {
                return HttpNotFound();
            }
            return View(filmler);
        }

        // POST: Admin/Filmler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FilmID,FilmAd,FilmImg,FragmanUrl,FilmKategori,Yapimi,Turu,Yonetmeni,Oyuncular,Senaryo,Yapimci,Ozeti,VizyonTarihi")] Filmler filmler, HttpPostedFileBase FilmImg)
        {
            if (ModelState.IsValid)
            {
                if (FilmImg != null && FilmImg.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(FilmImg.FileName);
                    fileName = Guid.NewGuid().ToString() + ".jpg";
                    fileName = fileName.Replace("-", "");
                    filmler.FilmImg = "/Content/p/" + fileName;
                    var path = Path.Combine(Server.MapPath("~/Content/p"), fileName);
                    FilmImg.SaveAs(path);
                }
                db.Entry(filmler).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(filmler);
        }

        // GET: Admin/Filmler/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filmler filmler = await db.Filmler.FindAsync(id);
            if (filmler == null)
            {
                return HttpNotFound();
            }
            return View(filmler);
        }

        // POST: Admin/Filmler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Filmler filmler = await db.Filmler.FindAsync(id);
            db.Filmler.Remove(filmler);
            var sld = db.Slider.ToList();
            foreach(var item in sld)
            {
                if(item.FilmID==id)
                {
                    db.Slider.Remove(item);
                }
            }
               /* Slider slider = db.Slider.FirstOrDefault(x => x.FilmID == id);
                if (slider != null)
                db.Slider.Remove(slider); */
           
            
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
