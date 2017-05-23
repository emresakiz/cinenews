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
    public class AdminHaberController : Controller
    {
        private SinemaBilgiModelEntities db = new SinemaBilgiModelEntities();

        // GET: Admin/AdminHaber
        public async Task<ActionResult> Index()
        {
            return View(await db.Haberler.ToListAsync());
        }

        // GET: Admin/AdminHaber/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Haberler haberler = await db.Haberler.FindAsync(id);
            if (haberler == null)
            {
                return HttpNotFound();
            }
            return View(haberler);
        }

        // GET: Admin/AdminHaber/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminHaber/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "HaberID,HaberImg,HaberBaslik,HaberKisa,HaberText")] Haberler haberler, HttpPostedFileBase HaberImg)
        {
            if (HaberImg != null && HaberImg.ContentLength > 0)
            {
                var fileName = Path.GetFileName(HaberImg.FileName);
                fileName = Guid.NewGuid().ToString() + ".jpg";
                fileName = fileName.Replace("-", "");
                haberler.HaberImg = "/Content/p/" + fileName;
                var path = Path.Combine(Server.MapPath("~/Content/p"), fileName);
                HaberImg.SaveAs(path);
            }

            db.Haberler.Add(haberler);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: Admin/AdminHaber/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Haberler haberler = await db.Haberler.FindAsync(id);
            if (haberler == null)
            {
                return HttpNotFound();
            }
            return View(haberler);
        }

        // POST: Admin/AdminHaber/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "HaberID,HaberImg,HaberBaslik,HaberKisa,HaberText")] Haberler haberler, HttpPostedFileBase HaberImg)
        {
            if (ModelState.IsValid)
            {
                if (HaberImg != null && HaberImg.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(HaberImg.FileName);
                    fileName = Guid.NewGuid().ToString() + ".jpg";
                    fileName = fileName.Replace("-", "");
                    haberler.HaberImg = "/Content/p/" + fileName;
                    var path = Path.Combine(Server.MapPath("~/Content/p"), fileName);
                    HaberImg.SaveAs(path);
                }
                db.Entry(haberler).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(haberler);
        }

        // GET: Admin/AdminHaber/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Haberler haberler = await db.Haberler.FindAsync(id);
            if (haberler == null)
            {
                return HttpNotFound();
            }
            return View(haberler);
        }

        // POST: Admin/AdminHaber/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Haberler haberler = await db.Haberler.FindAsync(id);
            db.Haberler.Remove(haberler);
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
