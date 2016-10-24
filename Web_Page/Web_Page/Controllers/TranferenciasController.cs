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
    public class TranferenciasController : Controller
    {
        private Banco1Entities db = new Banco1Entities();

        // GET: Tranferencias
        public async Task<ActionResult> Index()
        {
            var tranferencias = db.Tranferencias.Include(t => t.Cuenta);
            return View(await tranferencias.ToListAsync());
        }

        // GET: Tranferencias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tranferencia tranferencia = await db.Tranferencias.FindAsync(id);
            if (tranferencia == null)
            {
                return HttpNotFound();
            }
            return View(tranferencia);
        }

        // GET: Tranferencias/Create
        public ActionResult Create()
        {
            ViewBag.CodCuenta = new SelectList(db.Cuentas, "CodigCuenta", "CodigCuenta");
            return View();
        }

        // POST: Tranferencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CodTranf,CodCuenta,Tipocuenta,MontoR,fecha")] Tranferencia tranferencia)
        {
            if (ModelState.IsValid)
            {
                db.Tranferencias.Add(tranferencia);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CodCuenta = new SelectList(db.Cuentas, "CodigCuenta", "CodigCuenta", tranferencia.CodCuenta);
            return View(tranferencia);
        }

        // GET: Tranferencias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tranferencia tranferencia = await db.Tranferencias.FindAsync(id);
            if (tranferencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodCuenta = new SelectList(db.Cuentas, "CodigCuenta", "CodigCuenta", tranferencia.CodCuenta);
            return View(tranferencia);
        }

        // POST: Tranferencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CodTranf,CodCuenta,Tipocuenta,MontoR,fecha")] Tranferencia tranferencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tranferencia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CodCuenta = new SelectList(db.Cuentas, "CodigCuenta", "CodigCuenta", tranferencia.CodCuenta);
            return View(tranferencia);
        }

        // GET: Tranferencias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tranferencia tranferencia = await db.Tranferencias.FindAsync(id);
            if (tranferencia == null)
            {
                return HttpNotFound();
            }
            return View(tranferencia);
        }

        // POST: Tranferencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tranferencia tranferencia = await db.Tranferencias.FindAsync(id);
            db.Tranferencias.Remove(tranferencia);
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
