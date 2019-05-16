using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using ProjetoBanco.Context;
using ProjetoBanco.Models.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBanco.Controllers.Mongo
{
    public class Produto_MongoController : Controller
    {
        MongoContext _dbContext;
        public Produto_MongoController()
        {
            _dbContext = new MongoContext();
        }
        // GET: Produto_Mongo
        public ActionResult Index()
        {
            var produtosDetails = _dbContext._database.GetCollection<Produto_Mongo>("Produtos").FindAll().ToList();
            return View(produtosDetails);
        }

        // GET: Produto_Mongo/Details/5
        public ActionResult Details(string nome)
        {
            var produtosNome = Query<Produto_Mongo>.EQ(p => p.Nome, nome.ToString());
            var produtoDetail = _dbContext._database.GetCollection<Produto_Mongo>("Produtos").FindOne(produtosNome);
            return View(produtoDetail);
        }

        // GET: Produto_Mongo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto_Mongo/Create
        [HttpPost]
        public ActionResult Create(Produto_Mongo produto)
        {
            try
            {
                var document = _dbContext._database.GetCollection<BsonDocument>("Produtos");

                document.Insert(produto);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["Message"] = "Ocorreu um erro desconhecido na inserção!";
                return View("Create", produto);
            }
        }

        // GET: Produto_Mongo/Edit/5
        public ActionResult Edit(string nome)
        {
            var document = _dbContext._database.GetCollection<Produto_Mongo>("Produtos");

            var produtoNome = Query<Produto_Mongo>.EQ(p => p.Nome, nome.ToString());

            var produtoDetail = _dbContext._database.GetCollection<Produto_Mongo>("Produtos").FindOne(produtoNome);

            return View(produtoDetail);
        }

        // POST: Produto_Mongo/Edit/5
        [HttpPost]
        public ActionResult Edit(string nome, Produto_Mongo produto)
        {
            var produtoNome = Query<Produto_Mongo>.EQ(p => p.Nome, nome.ToString());

            var collection = _dbContext._database.GetCollection<Produto_Mongo>("Produtos");

            collection.Update(produtoNome, Update.Replace(produto), UpdateFlags.None);

            return RedirectToAction("Index");
        }

        // GET: Produto_Mongo/Delete/5
        public ActionResult Delete(string nome)
        {
            var produtoNome = Query<Produto_Mongo>.EQ(p => p.Nome, nome.ToString());

            var produtoDetail = _dbContext._database.GetCollection<Produto_Mongo>("Produtos").FindOne(produtoNome);

            return View(produtoDetail);
        }

        // POST: Produto_Mongo/Delete/5
        [HttpPost]
        public ActionResult Delete(string nome, Produto_Mongo produto)
        {
            var produtoNome = Query<Produto_Mongo>.EQ(p => p.Nome, nome.ToString());

            var collection = _dbContext._database.GetCollection<Produto_Mongo>("Produtos");

            collection.Remove(produtoNome, RemoveFlags.Single);

            return RedirectToAction("Index");
        }
    }
}
