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
    public class ProdutosController : Controller
    {
        private ProjetoBancoContext db = new ProjetoBancoContext();

        // GET: Produtos
        public ActionResult Index()
        {
            var produtos = db.Produtos.Include(p => p.Materia_Prima);
            return View(produtos.ToList());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id, string nome)
        {
            if (id == null || nome == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos produtos = db.Produtos.Find(id, nome);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            return View(produtos);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.ID_Materia_Principal = new SelectList(db.Materia_Prima, "ID_Materia_Prima", "Custo");
            return View();
        }

        // POST: Produtos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Produtos,Nome,Tempo_Producao_Minutos,ID_Materia_Principal,Nome_Materia_Principal,Lucro_Producao")] Produtos produtos)
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(produtos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Materia_Principal = new SelectList(db.Materia_Prima, "ID_Materia_Prima", "Custo", produtos.ID_Materia_Principal);
            return View(produtos);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id, string nome)
        {
            if (id == null || nome == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos produtos = db.Produtos.Find(id, nome);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Materia_Principal = new SelectList(db.Materia_Prima, "ID_Materia_Prima", "Custo", produtos.ID_Materia_Principal);
            return View(produtos);
        }

        // POST: Produtos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Produtos,Nome,Tempo_Producao_Minutos,ID_Materia_Principal,Nome_Materia_Principal,Lucro_Producao")] Produtos produtos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Materia_Principal = new SelectList(db.Materia_Prima, "ID_Materia_Prima", "Custo", produtos.ID_Materia_Principal);
            return View(produtos);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id, string nome)
        {
            if (id == null || nome == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos produtos = db.Produtos.Find(id, nome);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            return View(produtos);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string nome)
        {
            Produtos produtos = db.Produtos.Find(id,nome);
            db.Produtos.Remove(produtos);
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
