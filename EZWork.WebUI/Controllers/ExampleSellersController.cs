using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EZWork.Core.DBContext;
using EZWork.Core.Entities;

namespace EZWork.WebUI.Controllers
{
    public class ExampleSellersController : Controller
    {
        private EZWorkDbContext db = new EZWorkDbContext();

        // GET: ExampleSellers
        public async Task<ActionResult> Index()
        {
            var sellers = db.Sellers.Include(s => s.EZUser);
            return View(await sellers.ToListAsync());
        }

        // GET: ExampleSellers/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seller seller = await db.Sellers.FindAsync(id);
            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(seller);
        }

        // GET: ExampleSellers/Create
        public ActionResult Create()
        {
            ViewBag.SellerId = new SelectList(db.EZUsers, "Id", "FullName");
            return View();
        }

        // POST: ExampleSellers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SellerId,ShortDescription,Description,CreateAt,Status,Rate,FeedBackCount,CareerTitle")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                db.Sellers.Add(seller);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SellerId = new SelectList(db.EZUsers, "Id", "FullName", seller.SellerId);
            return View(seller);
        }

        // GET: ExampleSellers/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seller seller = await db.Sellers.FindAsync(id);
            if (seller == null)
            {
                return HttpNotFound();
            }
            ViewBag.SellerId = new SelectList(db.EZUsers, "Id", "FullName", seller.SellerId);
            return View(seller);
        }

        // POST: ExampleSellers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SellerId,ShortDescription,Description,CreateAt,Status,Rate,FeedBackCount,CareerTitle")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seller).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SellerId = new SelectList(db.EZUsers, "Id", "FullName", seller.SellerId);
            return View(seller);
        }

        // GET: ExampleSellers/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seller seller = await db.Sellers.FindAsync(id);
            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(seller);
        }

        // POST: ExampleSellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Seller seller = await db.Sellers.FindAsync(id);
            db.Sellers.Remove(seller);
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
