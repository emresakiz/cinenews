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
{
    [Authorize(Roles = "Admin")]
    public class SlidersController : Controller
    {
        private SinemaBilgiModelEntities db = new SinemaBilgiModelEntities();

        // GET: Admin/Sliders
        public async Task<ActionResult> Index()
        {
            var slider = db.Slider.Include(s => s.Filmler);
            return View(await slider.ToListAsync());
        }

        // GET: Admin/Sliders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = await db.Slider.FindAsync(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: Admin/Sliders/Create
        public ActionResult Create()
        {
            ViewBag.FilmID = new SelectList(db.Filmler, "FilmID", "FilmAd");
            return View();
        }

        // POST: Admin/Sliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SliderId,SliderUrl,SliderAd,SliderKisa,SliderNo,FilmID")] Slider slider, HttpPostedFileBase SliderUrl)
        {
            if (ModelState.IsValid)
            {
                if (SliderUrl != null && SliderUrl.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(SliderUrl.FileName);
                    fileName = Guid.NewGuid().ToString() + ".jpg";
                    fileName = fileName.Replace("-", "");
                    slider.SliderUrl = "/Content/p/" + fileName;
                    var path = Path.Combine(Server.MapPath("~/Content/p"), fileName);
                    SliderUrl.SaveAs(path);
                }
                db.Slider.Add(slider);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FilmID = new SelectList(db.Filmler, "FilmID", "FilmAd", slider.FilmID);
            return View(slider);
        }

        // GET: Admin/Sliders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = await db.Slider.FindAsync(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmID = new SelectList(db.Filmler, "FilmID", "FilmAd", slider.FilmID);
            return View(slider);
        }

        // POST: Admin/Sliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SliderId,SliderUrl,SliderAd,SliderKisa,SliderNo,FilmID")] Slider slider, HttpPostedFileBase SliderUrl)
        {
            if (ModelState.IsValid)
            {
                if (SliderUrl != null && SliderUrl.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(SliderUrl.FileName);
                    fileName = Guid.NewGuid().ToString() + ".jpg";
                    fileName = fileName.Replace("-", "");
                    slider.SliderUrl = "/Content/p/" + fileName;
                    var path = Path.Combine(Server.MapPath("~/Content/p"), fileName);
                    SliderUrl.SaveAs(path);
                }
                db.Entry(slider).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FilmID = new SelectList(db.Filmler, "FilmID", "FilmAd", slider.FilmID);
            return View(slider);
        }

        // GET: Admin/Sliders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = await db.Slider.FindAsync(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Admin/Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Slider slider = await db.Slider.FindAsync(id);
            db.Slider.Remove(slider);
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
