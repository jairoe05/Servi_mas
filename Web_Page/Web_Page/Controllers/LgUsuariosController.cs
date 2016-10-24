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
    public class LgUsuariosController : Controller
    {
        private Banco1Entities db = new Banco1Entities();

        // GET: LgUsuarios
        public async Task<ActionResult> Index()
        {
            var lgUsuarios = db.LgUsuarios.Include(l => l.Usuario1);
            return View(await lgUsuarios.ToListAsync());
        }

        // GET: LgUsuarios/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LgUsuario lgUsuario = await db.LgUsuarios.FindAsync(id);
            if (lgUsuario == null)
            {
                return HttpNotFound();
            }
            return View(lgUsuario);
        }

        // GET: LgUsuarios/Create
        public ActionResult Create()
        {
            ViewBag.Cedula = new SelectList(db.Usuarios, "Cedula", "Nombre");
            return View();
        }

        // POST: LgUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Usuario,Contraseña,Estado,Cedula")] LgUsuario lgUsuario)
        {
            if (ModelState.IsValid)
            {
                db.LgUsuarios.Add(lgUsuario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Cedula = new SelectList(db.Usuarios, "Cedula", "Nombre", lgUsuario.Cedula);
            return View(lgUsuario);
        }

        // GET: LgUsuarios/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LgUsuario lgUsuario = await db.LgUsuarios.FindAsync(id);
            if (lgUsuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cedula = new SelectList(db.Usuarios, "Cedula", "Nombre", lgUsuario.Cedula);
            return View(lgUsuario);
        }

        // POST: LgUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Usuario,Contraseña,Estado,Cedula")] LgUsuario lgUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lgUsuario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Cedula = new SelectList(db.Usuarios, "Cedula", "Nombre", lgUsuario.Cedula);
            return View(lgUsuario);
        }

        // GET: LgUsuarios/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LgUsuario lgUsuario = await db.LgUsuarios.FindAsync(id);
            if (lgUsuario == null)
            {
                return HttpNotFound();
            }
            return View(lgUsuario);
        }

        // POST: LgUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            LgUsuario lgUsuario = await db.LgUsuarios.FindAsync(id);
            db.LgUsuarios.Remove(lgUsuario);
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
