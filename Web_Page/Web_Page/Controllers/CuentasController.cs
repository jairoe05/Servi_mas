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
    public class CuentasController : Controller
    {
        private Banco1Entities db = new Banco1Entities();

        // GET: Cuentas
        public async Task<ActionResult> Index()
        {
            var cuentas = db.Cuentas.Include(c => c.Usuario).Include(c => c.TiposCuenta);
            return View(await cuentas.ToListAsync());
        }

        // GET: Cuentas/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuenta cuenta = await db.Cuentas.FindAsync(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            return View(cuenta);
        }

        // GET: Cuentas/Create
        public ActionResult Create()
        {
            ViewBag.Cedula = new SelectList(db.Usuarios, "Cedula", "Nombre");
            ViewBag.TipoCuenta = new SelectList(db.TiposCuentas, "CodCuenta", "Descripcion");
            return View();
        }

        // POST: Cuentas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CodigCuenta,TipoCuenta,Cedula,Monto")] Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                db.Cuentas.Add(cuenta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Cedula = new SelectList(db.Usuarios, "Cedula", "Nombre", cuenta.Cedula);
            ViewBag.TipoCuenta = new SelectList(db.TiposCuentas, "CodCuenta", "Descripcion", cuenta.TipoCuenta);
            return View(cuenta);
        }

        // GET: Cuentas/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuenta cuenta = await db.Cuentas.FindAsync(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cedula = new SelectList(db.Usuarios, "Cedula", "Nombre", cuenta.Cedula);
            ViewBag.TipoCuenta = new SelectList(db.TiposCuentas, "CodCuenta", "Descripcion", cuenta.TipoCuenta);
            return View(cuenta);
        }

        // POST: Cuentas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CodigCuenta,TipoCuenta,Cedula,Monto")] Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuenta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Cedula = new SelectList(db.Usuarios, "Cedula", "Nombre", cuenta.Cedula);
            ViewBag.TipoCuenta = new SelectList(db.TiposCuentas, "CodCuenta", "Descripcion", cuenta.TipoCuenta);
            return View(cuenta);
        }

        // GET: Cuentas/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuenta cuenta = await db.Cuentas.FindAsync(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            return View(cuenta);
        }

        // POST: Cuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Cuenta cuenta = await db.Cuentas.FindAsync(id);
            db.Cuentas.Remove(cuenta);
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
