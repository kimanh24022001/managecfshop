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
using System.Xml.Linq;

namespace managecfshop.Controllers
{
    public class SelectMenusController : Controller
    {
        private managecfshopContext db = new managecfshopContext();

        // GET: SelectMenus
        public ActionResult Index()
        {
            return View(db.SelectMenus.ToList());
        }

        // GET: SelectMenus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelectMenu selectMenu = db.SelectMenus.Find(id);
            if (selectMenu == null)
            {
                return HttpNotFound();
            }
            return View(selectMenu);
        }

        public ActionResult complete()
        {
            foreach (var bill in db.BillInfors.ToList())
            {
                bill.SelectedNameTable = "";
                db.BillInfors.Remove(bill);
                db.SaveChanges();
            }
            foreach (var menu in db.SelectMenus.ToList())
            {
                if (menu.AddToCart > 0)
                {
                    db.BillInfors.Add(new BillInfor { Food = menu.NameFood, Price = (int)menu.PriceFood, Amount = menu.AddToCart });
                }
            }
             db.SaveChanges();
            return RedirectToAction("Index", "BillInfors");
        }
        public ActionResult Add(int Id)
        {
            foreach (var menu in db.SelectMenus.ToList())
            {
                if (menu.Id == Id)
                { menu.AddToCart +=1; }
            }
            db.SaveChanges();
            return RedirectToAction("Index", "SelectMenus");
        }

        public ActionResult Sub(int Id)
        {
            foreach (var menu in db.SelectMenus.ToList())
            {
                if (menu.Id == Id)
                { menu.AddToCart -= 1; }
            }
            db.SaveChanges();
            return RedirectToAction("Index", "SelectMenus");
        }

        // GET: SelectMenus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SelectMenus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameFood,CountFood,PriceFood,Category,UploadFile,AddToCart")] SelectMenu selectMenu)
        {
            if (ModelState.IsValid)
            {
                db.SelectMenus.Add(selectMenu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(selectMenu);
        }

        // GET: SelectMenus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelectMenu selectMenu = db.SelectMenus.Find(id);
            if (selectMenu == null)
            {
                return HttpNotFound();
            }
            return View(selectMenu);
        }

        // POST: SelectMenus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameFood,CountFood,PriceFood,Category,UploadFile,AddToCart")] SelectMenu selectMenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(selectMenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(selectMenu);
        }

        // GET: SelectMenus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelectMenu selectMenu = db.SelectMenus.Find(id);
            if (selectMenu == null)
            {
                return HttpNotFound();
            }
            return View(selectMenu);
        }

        // POST: SelectMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SelectMenu selectMenu = db.SelectMenus.Find(id);
            db.SelectMenus.Remove(selectMenu);
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
