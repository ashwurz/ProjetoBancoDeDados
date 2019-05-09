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
    public class EstoqueProdutosController : Controller
    {
        private ProjetoBancoContext db = new ProjetoBancoContext();

        // GET: EstoqueProdutos
        public ActionResult Index()
        {
            var estoque_Produtos = db.Estoque_Produtos.Include(e => e.Produtos);
            return View(estoque_Produtos.ToList());
        }

        // GET: EstoqueProdutos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque_Produtos estoque_Produtos = db.Estoque_Produtos.Find(id);
            if (estoque_Produtos == null)
            {
                return HttpNotFound();
            }
            return View(estoque_Produtos);
        }

        // GET: EstoqueProdutos/Create
        public ActionResult Create()
        {
            ViewBag.ID_Produto = new SelectList(db.Produtos, "ID_Produtos", "Nome_Materia_Principal");
            return View();
        }

        // POST: EstoqueProdutos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sequencia_Estoque,ID_Produto,Nome,Quantidade")] Estoque_Produtos estoque_Produtos)
        {
            if (ModelState.IsValid)
            {
                db.Estoque_Produtos.Add(estoque_Produtos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Produto = new SelectList(db.Produtos, "ID_Produtos", "Nome_Materia_Principal", estoque_Produtos.ID_Produto);
            return View(estoque_Produtos);
        }

        // GET: EstoqueProdutos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque_Produtos estoque_Produtos = db.Estoque_Produtos.Find(id);
            if (estoque_Produtos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Produto = new SelectList(db.Produtos, "ID_Produtos", "Nome_Materia_Principal", estoque_Produtos.ID_Produto);
            return View(estoque_Produtos);
        }

        // POST: EstoqueProdutos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sequencia_Estoque,ID_Produto,Nome,Quantidade")] Estoque_Produtos estoque_Produtos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estoque_Produtos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Produto = new SelectList(db.Produtos, "ID_Produtos", "Nome_Materia_Principal", estoque_Produtos.ID_Produto);
            return View(estoque_Produtos);
        }

        // GET: EstoqueProdutos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque_Produtos estoque_Produtos = db.Estoque_Produtos.Find(id);
            if (estoque_Produtos == null)
            {
                return HttpNotFound();
            }
            return View(estoque_Produtos);
        }

        // POST: EstoqueProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estoque_Produtos estoque_Produtos = db.Estoque_Produtos.Find(id);
            db.Estoque_Produtos.Remove(estoque_Produtos);
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
