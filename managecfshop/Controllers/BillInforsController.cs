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
using System.Text;

namespace managecfshop.Controllers
{
    public class BillInforsController : Controller
    {
        private managecfshopContext db = new managecfshopContext();

        // GET: BillInfors
        public ActionResult Index()
        {
            return View(db.BillInfors.ToList());
        }

        public ActionResult ExportToCSV()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Food,Price,Amount");
            var totalPrice = 0;
            string selectedTb = "";
            foreach (var table in db.Tables.ToList())
            {
                if (table.NameTable == table.SelectedNameTable) 
                {
                    table.StatusTable = "Full";
                }
               selectedTb = table.SelectedNameTable;
            }
                foreach (var bill in db.BillInfors.ToList())
            {
                builder.AppendLine($"{bill.Food},{bill.Price},{bill.Amount}");
                totalPrice = totalPrice + bill.Price * bill.Amount;
               
                foreach (var menu in db.SelectMenus.ToList())
                {
                    if (bill.Food == menu.NameFood)
                    {
                        menu.CountFood -= bill.Amount;
                    }
                }
            }
            builder.AppendLine($"{"DateCheckIn"},{"Selected Table"},{"Total Price"}");
            builder.AppendLine($"{DateTime.Now},{selectedTb},{totalPrice}");
            db.Bills.Add(new Bill { DateCheckIn = DateTime.Now, IdTable = selectedTb, TotalPrice = totalPrice });
            db.SaveChanges();
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "data.csv");
        }
        public ActionResult TotalPrice()
        {
            var totalprice = 0;
            foreach (var bill in db.BillInfors.ToList())
            {
                totalprice += bill.Price;
            }
            return View(db.BillInfors.ToList());
        }

        // GET: BillInfors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillInfor billInfor = db.BillInfors.Find(id);
            if (billInfor == null)
            {
                return HttpNotFound();
            }
            return View(billInfor);
        }

        // GET: BillInfors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BillInfors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Food,Price,Amount")] BillInfor billInfor)
        {
            if (ModelState.IsValid)
            {
                foreach (var menu in db.SelectMenus.ToList())
                {
                    if (billInfor.Food == menu.NameFood)
                    {
                        billInfor.Price = (int)menu.PriceFood;
                    };
                }
                // menu = db.SelectMenus.Find(menu.NameFood, billInfor.Food);
                db.BillInfors.Add(billInfor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(billInfor);
        }

        // GET: BillInfors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillInfor billInfor = db.BillInfors.Find(id);
            if (billInfor == null)
            {
                return HttpNotFound();
            }
            return View(billInfor);
        }

        // POST: BillInfors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Food,Price,Amount")] BillInfor billInfor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billInfor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(billInfor);
        }

        // GET: BillInfors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillInfor billInfor = db.BillInfors.Find(id);
            if (billInfor == null)
            {
                return HttpNotFound();
            }
            return View(billInfor);
        }

        public ActionResult DeleteAll()
        {
            foreach (var bill in db.BillInfors.ToList())
            {
                bill.SelectedNameTable = "";
                db.BillInfors.Remove(bill);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        // POST: BillInfors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BillInfor billInfor = db.BillInfors.Find(id);
            db.BillInfors.Remove(billInfor);
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
