using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoBanco.Context;
using ProjetoBanco.Models;

namespace ProjetoBanco.Controllers
{
    public class EstoqueMateriaPrimaController : Controller
    {
        private ProjetoBancoContext db = new ProjetoBancoContext();

        // GET: EstoqueMateriaPrima
        public ActionResult Index()
        {
            var estoque_Materia_Prima = db.Estoque_Materia_Prima.Include(e => e.Materia_Prima);
            return View(estoque_Materia_Prima.ToList());
        }

        // GET: EstoqueMateriaPrima/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque_Materia_Prima estoque_Materia_Prima = db.Estoque_Materia_Prima.Find(id);
            if (estoque_Materia_Prima == null)
            {
                return HttpNotFound();
            }
            return View(estoque_Materia_Prima);
        }

        // GET: EstoqueMateriaPrima/Create
        public ActionResult Create()
        {
            ViewBag.ID_Materia_Prima = new SelectList(db.Materia_Prima, "ID_Materia_Prima", "Custo");
            return View();
        }

        // POST: EstoqueMateriaPrima/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sequencia_Estoque,ID_Materia_Prima,Nome,Quantidade")] Estoque_Materia_Prima estoque_Materia_Prima)
        {
            if (ModelState.IsValid)
            {
                db.Estoque_Materia_Prima.Add(estoque_Materia_Prima);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Materia_Prima = new SelectList(db.Materia_Prima, "ID_Materia_Prima", "Custo", estoque_Materia_Prima.ID_Materia_Prima);
            return View(estoque_Materia_Prima);
        }

        // GET: EstoqueMateriaPrima/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque_Materia_Prima estoque_Materia_Prima = db.Estoque_Materia_Prima.Find(id);
            if (estoque_Materia_Prima == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Materia_Prima = new SelectList(db.Materia_Prima, "ID_Materia_Prima", "Custo", estoque_Materia_Prima.ID_Materia_Prima);
            return View(estoque_Materia_Prima);
        }

        // POST: EstoqueMateriaPrima/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sequencia_Estoque,ID_Materia_Prima,Nome,Quantidade")] Estoque_Materia_Prima estoque_Materia_Prima)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estoque_Materia_Prima).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Materia_Prima = new SelectList(db.Materia_Prima, "ID_Materia_Prima", "Custo", estoque_Materia_Prima.ID_Materia_Prima);
            return View(estoque_Materia_Prima);
        }

        // GET: EstoqueMateriaPrima/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque_Materia_Prima estoque_Materia_Prima = db.Estoque_Materia_Prima.Find(id);
            if (estoque_Materia_Prima == null)
            {
                return HttpNotFound();
            }
            return View(estoque_Materia_Prima);
        }

        // POST: EstoqueMateriaPrima/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estoque_Materia_Prima estoque_Materia_Prima = db.Estoque_Materia_Prima.Find(id);
            db.Estoque_Materia_Prima.Remove(estoque_Materia_Prima);
            db.SaveChanges();
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
