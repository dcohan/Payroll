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
    public class EmployeeIncomesController : Controller
    {
        private PayrollEntities db = new PayrollEntities();

        // GET: EmployeeIncomes
        public async Task<ActionResult> Index()
        {
            var employeeIncomes = db.EmployeeIncomes.Include(e => e.Employee);
            return View(await employeeIncomes.ToListAsync());
        }

        // GET: EmployeeIncomes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeIncome employeeIncome = await db.EmployeeIncomes.FindAsync(id);
            if (employeeIncome == null)
            {
                return HttpNotFound();
            }
            return View(employeeIncome);
        }

        // GET: EmployeeIncomes/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name");
            return View();
        }

        // POST: EmployeeIncomes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,EmployeeId,AnnualSalary,StartDate,SuperRate")] EmployeeIncome employeeIncome)
        {
            if (ModelState.IsValid)
            {
                employeeIncome.CreationDateTime = DateTimeOffset.UtcNow;
                db.EmployeeIncomes.Add(employeeIncome);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", employeeIncome.EmployeeId);
            return View(employeeIncome);
        }

        // GET: EmployeeIncomes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeIncome employeeIncome = await db.EmployeeIncomes.FindAsync(id);
            if (employeeIncome == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", employeeIncome.EmployeeId);
            return View(employeeIncome);
        }

        // POST: EmployeeIncomes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,EmployeeId,AnnualSalary,StartDate,CreationDateTime,SuperRate")] EmployeeIncome employeeIncome)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeIncome).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", employeeIncome.EmployeeId);
            return View(employeeIncome);
        }

        // GET: EmployeeIncomes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeIncome employeeIncome = await db.EmployeeIncomes.FindAsync(id);
            if (employeeIncome == null)
            {
                return HttpNotFound();
            }
            return View(employeeIncome);
        }

        // POST: EmployeeIncomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EmployeeIncome employeeIncome = await db.EmployeeIncomes.FindAsync(id);
            db.EmployeeIncomes.Remove(employeeIncome);
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
