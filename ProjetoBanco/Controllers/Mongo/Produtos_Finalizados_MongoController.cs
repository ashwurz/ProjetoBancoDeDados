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
    public class Produtos_Finalizados_MongoController : Controller
    {
        MongoContext _dbContext;
        public Produtos_Finalizados_MongoController()
        {
            _dbContext = new MongoContext();
        }
        // GET: Produtos_Finalizados_Mongo
        public ActionResult Index()
        {
            var produtosDetails = _dbContext._database.GetCollection<Produtos_Finalizados_Mongo>("Produtos_Finalizados").FindAll().ToList();
            return View(produtosDetails);
        }

        // GET: Produtos_Finalizados_Mongo/Details/5
        public ActionResult Details(int id)
        {
            var produtosNome = Query<Produtos_Finalizados_Mongo>.EQ(p => p.Sequencia_Producao, id);
            var produtoDetail = _dbContext._database.GetCollection<Produtos_Finalizados_Mongo>("Produtos_Finalizados").FindOne(produtosNome);
            return View(produtoDetail);
        }

        // GET: Produtos_Finalizados_Mongo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produtos_Finalizados_Mongo/Create
        [HttpPost]
        public ActionResult Create(Produtos_Finalizados_Mongo produtos)
        {
            try
            {
                var document = _dbContext._database.GetCollection<BsonDocument>("Produtos_Finalizados");

                document.Insert(produtos);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Ocorreu um erro desconhecido na inserção!";
                return View("Create", produtos);
            }
        }

        // GET: Produtos_Finalizados_Mongo/Edit/5
        public ActionResult Edit(int id)
        {
            var document = _dbContext._database.GetCollection<Produtos_Finalizados_Mongo>("Produtos_Finalizados");

            var produtoNome = Query<Produtos_Finalizados_Mongo>.EQ(p => p.Sequencia_Producao, id);

            var produtoDetail = _dbContext._database.GetCollection<Produtos_Finalizados_Mongo>("Produtos_Finalizados").FindOne(produtoNome);

            return View(produtoDetail);
        }

        // POST: Produtos_Finalizados_Mongo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Produtos_Finalizados_Mongo produtos)
        {
            var produtoNome = Query<Produtos_Finalizados_Mongo>.EQ(p => p.Sequencia_Producao, id);

            var collection = _dbContext._database.GetCollection<Produtos_Finalizados_Mongo>("Produtos_Finalizados");

            collection.Update(produtoNome, Update.Replace(produtos), UpdateFlags.None);

            return RedirectToAction("Index");
        }

        // GET: Produtos_Finalizados_Mongo/Delete/5
        public ActionResult Delete(int id)
        {
            var produtoNome = Query<Produtos_Finalizados_Mongo>.EQ(p => p.Sequencia_Producao, id);

            var produtoDetail = _dbContext._database.GetCollection<Produtos_Finalizados_Mongo>("Produtos_Finalizados").FindOne(produtoNome);

            return View(produtoDetail);
        }

        // POST: Produtos_Finalizados_Mongo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Produtos_Finalizados_Mongo produtos)
        {
            var produtoNome = Query<Produtos_Finalizados_Mongo>.EQ(p => p.Sequencia_Producao, id);

            var collection = _dbContext._database.GetCollection<Produtos_Finalizados_Mongo>("Produtos_Finalizados");

            collection.Remove(produtoNome, RemoveFlags.Single);

            return RedirectToAction("Index");
        }
    }
}
