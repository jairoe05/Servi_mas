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
    public class TiposCuentasController : Controller
    {
        private Banco1Entities db = new Banco1Entities();

        // GET: TiposCuentas
        public async Task<ActionResult> Index()
        {
            return View(await db.TiposCuentas.ToListAsync());
        }

        // GET: TiposCuentas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposCuenta tiposCuenta = await db.TiposCuentas.FindAsync(id);
            if (tiposCuenta == null)
            {
                return HttpNotFound();
            }
            return View(tiposCuenta);
        }

        // GET: TiposCuentas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposCuentas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CodCuenta,Descripcion")] TiposCuenta tiposCuenta)
        {
            if (ModelState.IsValid)
            {
                db.TiposCuentas.Add(tiposCuenta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tiposCuenta);
        }

        // GET: TiposCuentas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposCuenta tiposCuenta = await db.TiposCuentas.FindAsync(id);
            if (tiposCuenta == null)
            {
                return HttpNotFound();
            }
            return View(tiposCuenta);
        }

        // POST: TiposCuentas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CodCuenta,Descripcion")] TiposCuenta tiposCuenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiposCuenta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tiposCuenta);
        }

        // GET: TiposCuentas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposCuenta tiposCuenta = await db.TiposCuentas.FindAsync(id);
            if (tiposCuenta == null)
            {
                return HttpNotFound();
            }
            return View(tiposCuenta);
        }

        // POST: TiposCuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TiposCuenta tiposCuenta = await db.TiposCuentas.FindAsync(id);
            db.TiposCuentas.Remove(tiposCuenta);
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
