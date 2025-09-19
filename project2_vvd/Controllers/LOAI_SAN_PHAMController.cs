using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using project2_vvd.Models;

namespace project2_vvd.Controllers
{
    public class LOAI_SAN_PHAMController : Controller
    {
        private CuaHangGiayTheThaoEntities db = new CuaHangGiayTheThaoEntities();

        // GET: LOAI_SAN_PHAM
        public ActionResult Index()
        {
            return View(db.LOAI_SAN_PHAM.ToList());
        }

        // GET: LOAI_SAN_PHAM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAI_SAN_PHAM lOAI_SAN_PHAM = db.LOAI_SAN_PHAM.Find(id);
            if (lOAI_SAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(lOAI_SAN_PHAM);
        }

        // GET: LOAI_SAN_PHAM/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LOAI_SAN_PHAM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MaLoai,TenLoai,TrangThai")] LOAI_SAN_PHAM lOAI_SAN_PHAM)
        {
            if (ModelState.IsValid)
            {
                db.LOAI_SAN_PHAM.Add(lOAI_SAN_PHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAI_SAN_PHAM);
        }

        // GET: LOAI_SAN_PHAM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAI_SAN_PHAM lOAI_SAN_PHAM = db.LOAI_SAN_PHAM.Find(id);
            if (lOAI_SAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(lOAI_SAN_PHAM);
        }

        // POST: LOAI_SAN_PHAM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MaLoai,TenLoai,TrangThai")] LOAI_SAN_PHAM lOAI_SAN_PHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAI_SAN_PHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAI_SAN_PHAM);
        }

        // GET: LOAI_SAN_PHAM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAI_SAN_PHAM lOAI_SAN_PHAM = db.LOAI_SAN_PHAM.Find(id);
            if (lOAI_SAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(lOAI_SAN_PHAM);
        }

        // POST: LOAI_SAN_PHAM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOAI_SAN_PHAM lOAI_SAN_PHAM = db.LOAI_SAN_PHAM.Find(id);
            db.LOAI_SAN_PHAM.Remove(lOAI_SAN_PHAM);
            db.SaveChanges();
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
