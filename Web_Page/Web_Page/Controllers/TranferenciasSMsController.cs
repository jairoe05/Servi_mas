using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_Page.Models;

namespace Web_Page.Controllers
{
    public class TranferenciasSMsController : Controller
    {
        private Banco1Entities db = new Banco1Entities();

        // GET: TranferenciasSMs
        public async Task<ActionResult> Index()
        {
            var tranferenciasSMS = db.TranferenciasSMS.Include(t => t.Cuenta);
            return View(await tranferenciasSMS.ToListAsync());
        }

        // GET: TranferenciasSMs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TranferenciasSM tranferenciasSM = await db.TranferenciasSMS.FindAsync(id);
            if (tranferenciasSM == null)
            {
                return HttpNotFound();
            }
            return View(tranferenciasSM);
        }

        // GET: TranferenciasSMs/Create
        public ActionResult Create()
        {
            ViewBag.CodigoCuenta = new SelectList(db.Cuentas, "CodigCuenta", "CodigCuenta");
            return View();
        }

        // POST: TranferenciasSMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "codtranferencia,CodigoCuenta,TelefonoAF,MontoR,TelefonoAR,Fecha")] TranferenciasSM tranferenciasSM)
        {
            if (ModelState.IsValid)
            {
                db.TranferenciasSMS.Add(tranferenciasSM);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoCuenta = new SelectList(db.Cuentas, "CodigCuenta", "CodigCuenta", tranferenciasSM.CodigoCuenta);
            return View(tranferenciasSM);
        }

        // GET: TranferenciasSMs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TranferenciasSM tranferenciasSM = await db.TranferenciasSMS.FindAsync(id);
            if (tranferenciasSM == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoCuenta = new SelectList(db.Cuentas, "CodigCuenta", "CodigCuenta", tranferenciasSM.CodigoCuenta);
            return View(tranferenciasSM);
        }

        // POST: TranferenciasSMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "codtranferencia,CodigoCuenta,TelefonoAF,MontoR,TelefonoAR,Fecha")] TranferenciasSM tranferenciasSM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tranferenciasSM).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoCuenta = new SelectList(db.Cuentas, "CodigCuenta", "CodigCuenta", tranferenciasSM.CodigoCuenta);
            return View(tranferenciasSM);
        }

        // GET: TranferenciasSMs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TranferenciasSM tranferenciasSM = await db.TranferenciasSMS.FindAsync(id);
            if (tranferenciasSM == null)
            {
                return HttpNotFound();
            }
            return View(tranferenciasSM);
        }

        // POST: TranferenciasSMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TranferenciasSM tranferenciasSM = await db.TranferenciasSMS.FindAsync(id);
            db.TranferenciasSMS.Remove(tranferenciasSM);
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
