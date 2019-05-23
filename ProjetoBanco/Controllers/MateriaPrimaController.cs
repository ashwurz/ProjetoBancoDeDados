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
    public class MateriaPrimaController : Controller
    {
        private ProjetoBancoContext db = new ProjetoBancoContext();

        // GET: MateriaPrima
        public ActionResult Index()
        {
            //var teste = db.Materia_Prima.OrderByDescending(x => x.Nome).ToList();
            return View(db.Materia_Prima.ToList());
        }

        // GET: MateriaPrima/Details/5
        public ActionResult Details(string nome)
        {
            if (nome == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materia_Prima materia_Prima = db.Materia_Prima.Find(nome);
            if (materia_Prima == null)
            {
                return HttpNotFound();
            }
            return View(materia_Prima);
        }

        // GET: MateriaPrima/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MateriaPrima/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Custo,Quantidade_Estoque")] Materia_Prima materia_Prima)
        {
            if (ModelState.IsValid)
            {
                db.Materia_Prima.Add(materia_Prima);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materia_Prima);
        }

        // GET: MateriaPrima/Edit/5
        public ActionResult Edit(string nome)
        {
            if (nome == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materia_Prima materia_Prima = db.Materia_Prima.Find(nome);
            if (materia_Prima == null)
            {
                return HttpNotFound();
            }
            return View(materia_Prima);
        }

        // POST: MateriaPrima/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nome,Custo,Quantidade_Estoque")] Materia_Prima materia_Prima)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materia_Prima).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materia_Prima);
        }

        // GET: MateriaPrima/Delete/5
        public ActionResult Delete(string nome)
        {
            if (nome == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materia_Prima materia_Prima = db.Materia_Prima.Find(nome);
            if (materia_Prima == null)
            {
                return HttpNotFound();
            }
            return View(materia_Prima);
        }

        // POST: MateriaPrima/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string nome)
        {
            Materia_Prima materia_Prima = db.Materia_Prima.Find(nome);
            db.Materia_Prima.Remove(materia_Prima);
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
