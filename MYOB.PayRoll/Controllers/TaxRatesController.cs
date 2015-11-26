using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MYOB.PayRoll.Entities;

namespace MYOB.PayRoll.Controllers
{
    public class TaxRatesController : Controller
    {
        private PayrollEntities db = new PayrollEntities();

        // GET: TaxRates
        public async Task<ActionResult> Index()
        {
            return View(await db.TaxRates.ToListAsync());
        }

        // GET: TaxRates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxRate taxRate = await db.TaxRates.FindAsync(id);
            if (taxRate == null)
            {
                return HttpNotFound();
            }
            return View(taxRate);
        }

        // GET: TaxRates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaxRates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Year,Month,GrossIncomeBase,GrossIncomeTop,TaxRate1,CreationDateTime")] TaxRate taxRate)
        {
            if (ModelState.IsValid)
            {
                db.TaxRates.Add(taxRate);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(taxRate);
        }

        // GET: TaxRates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxRate taxRate = await db.TaxRates.FindAsync(id);
            if (taxRate == null)
            {
                return HttpNotFound();
            }
            return View(taxRate);
        }

        // POST: TaxRates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Year,Month,GrossIncomeBase,GrossIncomeTop,TaxRate1,CreationDateTime")] TaxRate taxRate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taxRate).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(taxRate);
        }

        // GET: TaxRates/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxRate taxRate = await db.TaxRates.FindAsync(id);
            if (taxRate == null)
            {
                return HttpNotFound();
            }
            return View(taxRate);
        }

        // POST: TaxRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TaxRate taxRate = await db.TaxRates.FindAsync(id);
            db.TaxRates.Remove(taxRate);
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
