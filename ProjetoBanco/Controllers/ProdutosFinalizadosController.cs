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
    public class ProdutosFinalizadosController : Controller
    {
        private ProjetoBancoContext db = new ProjetoBancoContext();

        // GET: ProdutosFinalizados
        public ActionResult Index()
        {
            var produtos_Finalizados = db.Produtos_Finalizados.Include(p => p.Produtos);
            return View(produtos_Finalizados.ToList());
        }

        // GET: ProdutosFinalizados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos_Finalizados produtos_Finalizados = db.Produtos_Finalizados.Find(id);
            if (produtos_Finalizados == null)
            {
                return HttpNotFound();
            }
            return View(produtos_Finalizados);
        }

        // GET: ProdutosFinalizados/Create
        public ActionResult Create()
        {
            //ViewBag.ID_Produto = new SelectList(db.Produtos, "ID_Produtos", "Nome_Materia_Principal");
            return View();
        }

        // POST: ProdutosFinalizados/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sequencia_Producao,Nome,Data_Producao")] Produtos_Finalizados produtos_Finalizados)
        {
            if (ModelState.IsValid)
            {
                db.Produtos_Finalizados.Add(produtos_Finalizados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.ID_Produto = new SelectList(db.Produtos, "ID_Produtos", "Nome_Materia_Principal", produtos_Finalizados.ID_Produto);
            return View(produtos_Finalizados);
        }

        // GET: ProdutosFinalizados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos_Finalizados produtos_Finalizados = db.Produtos_Finalizados.Find(id);
            if (produtos_Finalizados == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ID_Produto = new SelectList(db.Produtos, "ID_Produtos", "Nome_Materia_Principal", produtos_Finalizados.ID_Produto);
            return View(produtos_Finalizados);
        }

        // POST: ProdutosFinalizados/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sequencia_Producao,Nome,Data_Producao")] Produtos_Finalizados produtos_Finalizados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtos_Finalizados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ID_Produto = new SelectList(db.Produtos, "ID_Produtos", "Nome_Materia_Principal", produtos_Finalizados.ID_Produto);
            return View(produtos_Finalizados);
        }

        // GET: ProdutosFinalizados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos_Finalizados produtos_Finalizados = db.Produtos_Finalizados.Find(id);
            if (produtos_Finalizados == null)
            {
                return HttpNotFound();
            }
            return View(produtos_Finalizados);
        }

        // POST: ProdutosFinalizados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produtos_Finalizados produtos_Finalizados = db.Produtos_Finalizados.Find(id);
            db.Produtos_Finalizados.Remove(produtos_Finalizados);
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
