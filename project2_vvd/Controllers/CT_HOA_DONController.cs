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
    public class CT_HOA_DONController : Controller
    {
        private CuaHangGiayTheThaoEntities db = new CuaHangGiayTheThaoEntities();

        // GET: CT_HOA_DON
        public ActionResult Index()
        {
            var cT_HOA_DON = db.CT_HOA_DON.Include(c => c.HOA_DON).Include(c => c.SAN_PHAM);
            return View(cT_HOA_DON.ToList());
        }

        // GET: CT_HOA_DON/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HOA_DON cT_HOA_DON = db.CT_HOA_DON.Find(id);
            if (cT_HOA_DON == null)
            {
                return HttpNotFound();
            }
            return View(cT_HOA_DON);
        }

        // GET: CT_HOA_DON/Create
        public ActionResult Create()
        {
            ViewBag.HoaDonID = new SelectList(db.HOA_DON, "ID", "MaHoaDon");
            ViewBag.SanPhamID = new SelectList(db.SAN_PHAM, "ID", "MaSanPham");
            return View();
        }

        // POST: CT_HOA_DON/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HoaDonID,SanPhamID,SoLuongMua,DonGiaMua,ThanhTien,TrangThai")] CT_HOA_DON cT_HOA_DON)
        {
            if (ModelState.IsValid)
            {
                db.CT_HOA_DON.Add(cT_HOA_DON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HoaDonID = new SelectList(db.HOA_DON, "ID", "MaHoaDon", cT_HOA_DON.HoaDonID);
            ViewBag.SanPhamID = new SelectList(db.SAN_PHAM, "ID", "MaSanPham", cT_HOA_DON.SanPhamID);
            return View(cT_HOA_DON);
        }

        // GET: CT_HOA_DON/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HOA_DON cT_HOA_DON = db.CT_HOA_DON.Find(id);
            if (cT_HOA_DON == null)
            {
                return HttpNotFound();
            }
            ViewBag.HoaDonID = new SelectList(db.HOA_DON, "ID", "MaHoaDon", cT_HOA_DON.HoaDonID);
            ViewBag.SanPhamID = new SelectList(db.SAN_PHAM, "ID", "MaSanPham", cT_HOA_DON.SanPhamID);
            return View(cT_HOA_DON);
        }

        // POST: CT_HOA_DON/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HoaDonID,SanPhamID,SoLuongMua,DonGiaMua,ThanhTien,TrangThai")] CT_HOA_DON cT_HOA_DON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_HOA_DON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HoaDonID = new SelectList(db.HOA_DON, "ID", "MaHoaDon", cT_HOA_DON.HoaDonID);
            ViewBag.SanPhamID = new SelectList(db.SAN_PHAM, "ID", "MaSanPham", cT_HOA_DON.SanPhamID);
            return View(cT_HOA_DON);
        }

        // GET: CT_HOA_DON/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HOA_DON cT_HOA_DON = db.CT_HOA_DON.Find(id);
            if (cT_HOA_DON == null)
            {
                return HttpNotFound();
            }
            return View(cT_HOA_DON);
        }

        // POST: CT_HOA_DON/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CT_HOA_DON cT_HOA_DON = db.CT_HOA_DON.Find(id);
            db.CT_HOA_DON.Remove(cT_HOA_DON);
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
