using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using coffeeShop.Models;
using managecfshop.Data;

namespace managecfshop.Controllers
{
    public class ABCsController : Controller
    {
        private managecfshopContext db = new managecfshopContext();

        // GET: ABCs
        public ActionResult Index()
        {
            return View(db.ABCs.ToList());
        }

        // GET: ABCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ABC aBC = db.ABCs.Find(id);
            if (aBC == null)
            {
                return HttpNotFound();
            }
            return View(aBC);
        }

        // GET: ABCs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ABCs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Status,Time")] ABC aBC)
        {
            if (ModelState.IsValid)
            {
                db.ABCs.Add(aBC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aBC);
        }

        // GET: ABCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ABC aBC = db.ABCs.Find(id);
            if (aBC == null)
            {
                return HttpNotFound();
            }
            return View(aBC);
        }

        // POST: ABCs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Status,Time")] ABC aBC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aBC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aBC);
        }

        // GET: ABCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ABC aBC = db.ABCs.Find(id);
            if (aBC == null)
            {
                return HttpNotFound();
            }
            return View(aBC);
        }

        // POST: ABCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ABC aBC = db.ABCs.Find(id);
            db.ABCs.Remove(aBC);
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
