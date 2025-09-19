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
    public class HOA_DONController : Controller
    {
        private CuaHangGiayTheThaoEntities db = new CuaHangGiayTheThaoEntities();

        // GET: HOA_DON
        public ActionResult Index()
        {
            var hOA_DON = db.HOA_DON.Include(h => h.KHACH_HANG);
            return View(hOA_DON.ToList());
        }

        // GET: HOA_DON/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOA_DON hOA_DON = db.HOA_DON.Find(id);
            if (hOA_DON == null)
            {
                return HttpNotFound();
            }
            return View(hOA_DON);
        }

        // GET: HOA_DON/Create
        public ActionResult Create()
        {
            ViewBag.MaKhachHang = new SelectList(db.KHACH_HANG, "ID", "MaKhachHang");
            return View();
        }

        // POST: HOA_DON/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MaHoaDon,MaKhachHang,NgayHoaDon,NgayHinh,HoTenKhachHang,Email,DienThoai,DiaChi,TongTriGia,TrangThai")] HOA_DON hOA_DON)
        {
            if (ModelState.IsValid)
            {
                db.HOA_DON.Add(hOA_DON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhachHang = new SelectList(db.KHACH_HANG, "ID", "MaKhachHang", hOA_DON.MaKhachHang);
            return View(hOA_DON);
        }

        // GET: HOA_DON/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOA_DON hOA_DON = db.HOA_DON.Find(id);
            if (hOA_DON == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhachHang = new SelectList(db.KHACH_HANG, "ID", "MaKhachHang", hOA_DON.MaKhachHang);
            return View(hOA_DON);
        }

        // POST: HOA_DON/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MaHoaDon,MaKhachHang,NgayHoaDon,NgayHinh,HoTenKhachHang,Email,DienThoai,DiaChi,TongTriGia,TrangThai")] HOA_DON hOA_DON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOA_DON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhachHang = new SelectList(db.KHACH_HANG, "ID", "MaKhachHang", hOA_DON.MaKhachHang);
            return View(hOA_DON);
        }

        // GET: HOA_DON/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOA_DON hOA_DON = db.HOA_DON.Find(id);
            if (hOA_DON == null)
            {
                return HttpNotFound();
            }
            return View(hOA_DON);
        }

        // POST: HOA_DON/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HOA_DON hOA_DON = db.HOA_DON.Find(id);
            db.HOA_DON.Remove(hOA_DON);
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
