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
    public class AfiliacionMBsController : Controller
    {
        private Banco1Entities db = new Banco1Entities();

        // GET: AfiliacionMBs
        public async Task<ActionResult> Index()
        {
            var afiliacionMBs = db.AfiliacionMBs.Include(a => a.Usuario).Include(a => a.Cuenta);
            return View(await afiliacionMBs.ToListAsync());
        }

        // GET: AfiliacionMBs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AfiliacionMB afiliacionMB = await db.AfiliacionMBs.FindAsync(id);
            if (afiliacionMB == null)
            {
                return HttpNotFound();
            }
            return View(afiliacionMB);
        }

        // GET: AfiliacionMBs/Create
        public ActionResult Create()
        {
            ViewBag.cedula = new SelectList(db.Usuarios, "Cedula", "Nombre");
            ViewBag.CodigoCuenta = new SelectList(db.Cuentas, "CodigCuenta", "CodigCuenta");
            return View();
        }

        // POST: AfiliacionMBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "cedula,CodigoCuenta,TelefonAfi,MontoTran,nickname")] AfiliacionMB afiliacionMB)
        {
            if (ModelState.IsValid)
            {
                db.AfiliacionMBs.Add(afiliacionMB);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.cedula = new SelectList(db.Usuarios, "Cedula", "Nombre", afiliacionMB.cedula);
            ViewBag.CodigoCuenta = new SelectList(db.Cuentas, "CodigCuenta", "CodigCuenta", afiliacionMB.CodigoCuenta);
            return View(afiliacionMB);
        }

        // GET: AfiliacionMBs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AfiliacionMB afiliacionMB = await db.AfiliacionMBs.FindAsync(id);
            if (afiliacionMB == null)
            {
                return HttpNotFound();
            }
            ViewBag.cedula = new SelectList(db.Usuarios, "Cedula", "Nombre", afiliacionMB.cedula);
            ViewBag.CodigoCuenta = new SelectList(db.Cuentas, "CodigCuenta", "CodigCuenta", afiliacionMB.CodigoCuenta);
            return View(afiliacionMB);
        }

        // POST: AfiliacionMBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "cedula,CodigoCuenta,TelefonAfi,MontoTran,nickname")] AfiliacionMB afiliacionMB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(afiliacionMB).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.cedula = new SelectList(db.Usuarios, "Cedula", "Nombre", afiliacionMB.cedula);
            ViewBag.CodigoCuenta = new SelectList(db.Cuentas, "CodigCuenta", "CodigCuenta", afiliacionMB.CodigoCuenta);
            return View(afiliacionMB);
        }

        // GET: AfiliacionMBs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AfiliacionMB afiliacionMB = await db.AfiliacionMBs.FindAsync(id);
            if (afiliacionMB == null)
            {
                return HttpNotFound();
            }
            return View(afiliacionMB);
        }

        // POST: AfiliacionMBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AfiliacionMB afiliacionMB = await db.AfiliacionMBs.FindAsync(id);
            db.AfiliacionMBs.Remove(afiliacionMB);
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
