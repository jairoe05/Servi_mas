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
    public class TranferenciasWebsController : Controller
    {
        private Banco1Entities db = new Banco1Entities();

        // GET: TranferenciasWebs
        public async Task<ActionResult> Index()
        {
            var tranferenciasWebs = db.TranferenciasWebs.Include(t => t.Cuenta);
            return View(await tranferenciasWebs.ToListAsync());
        }

        // GET: TranferenciasWebs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TranferenciasWeb tranferenciasWeb = await db.TranferenciasWebs.FindAsync(id);
            if (tranferenciasWeb == null)
            {
                return HttpNotFound();
            }
            return View(tranferenciasWeb);
        }

        // GET: TranferenciasWebs/Create
        public ActionResult Create()
        {
            ViewBag.CodigoCuenta = new SelectList(db.Cuentas, "CodigCuenta", "CodigCuenta");
            return View();
        }

        // POST: TranferenciasWebs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "codtranferencia,CodigoCuenta,TelefonoR,MontoR,Fecha")] TranferenciasWeb tranferenciasWeb)
        {
            if (ModelState.IsValid)
            {
                db.TranferenciasWebs.Add(tranferenciasWeb);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoCuenta = new SelectList(db.Cuentas, "CodigCuenta", "CodigCuenta", tranferenciasWeb.CodigoCuenta);
            return View(tranferenciasWeb);
        }

        // GET: TranferenciasWebs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TranferenciasWeb tranferenciasWeb = await db.TranferenciasWebs.FindAsync(id);
            if (tranferenciasWeb == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoCuenta = new SelectList(db.Cuentas, "CodigCuenta", "CodigCuenta", tranferenciasWeb.CodigoCuenta);
            return View(tranferenciasWeb);
        }

        // POST: TranferenciasWebs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "codtranferencia,CodigoCuenta,TelefonoR,MontoR,Fecha")] TranferenciasWeb tranferenciasWeb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tranferenciasWeb).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoCuenta = new SelectList(db.Cuentas, "CodigCuenta", "CodigCuenta", tranferenciasWeb.CodigoCuenta);
            return View(tranferenciasWeb);
        }

        // GET: TranferenciasWebs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TranferenciasWeb tranferenciasWeb = await db.TranferenciasWebs.FindAsync(id);
            if (tranferenciasWeb == null)
            {
                return HttpNotFound();
            }
            return View(tranferenciasWeb);
        }

        // POST: TranferenciasWebs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TranferenciasWeb tranferenciasWeb = await db.TranferenciasWebs.FindAsync(id);
            db.TranferenciasWebs.Remove(tranferenciasWeb);
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
