using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ManageCoffeeShop.Models;
using managecfshop.Data;

namespace managecfshop.Controllers
{
    public class TablesController : Controller
    {
        private managecfshopContext db = new managecfshopContext();

        // GET: Tables
        public ActionResult Index()
        {
            foreach (var table in db.Tables.ToList())
            {
                if (table.StatusTable == "Full")
                {
                    table.UploadFile = "data:image/png;base64,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";
                }
                else
                {
                    table.UploadFile = "https://cdn-icons-png.flaticon.com/512/5278/5278681.png";
                }
            }
            return View(db.Tables.ToList());
        }


        public ActionResult SelectTable(string tb)
        {
            var check = 0;
            foreach (var table in db.Tables.ToList())
            {
                foreach (var billinfor in db.BillInfors.ToList())
                {
                    if ((table.NameTable == tb) && (table.StatusTable == "Empty"))
                    {
                        table.SelectedNameTable = tb;
                        billinfor.SelectedNameTable = tb;
                        check = 1;
                        db.SaveChanges();
                        break;
                    }
                    if (check == 1) { break; }
                    else
                    {
                        table.SelectedNameTable = "";
                        billinfor.SelectedNameTable = "";
                        db.SaveChanges();
                    }
                }
            }
            
            return RedirectToAction("Index", "BillInfors");
        }

        // GET: Tables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table table = db.Tables.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            return View(table);
        }

        // GET: Tables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameTable,StatusTable,UploadFile")] Table table)
        {
            if (ModelState.IsValid)
            {
                db.Tables.Add(table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table);
        }

        // GET: Tables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table table = db.Tables.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            return View(table);
        }

        // POST: Tables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameTable,StatusTable,UploadFile")] Table table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table);
        }

        // GET: Tables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table table = db.Tables.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            return View(table);
        }

        // POST: Tables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table table = db.Tables.Find(id);
            db.Tables.Remove(table);
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
