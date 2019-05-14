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
    public class Materia_Prima_MongoController : Controller
    {
        MongoContext _dbContext;
        public Materia_Prima_MongoController()
        {
            _dbContext = new MongoContext();
        }

        // GET: Materia_Prima_Mongo
        public ActionResult Index()
        {
            var materiaPrimaDetails = _dbContext._database.GetCollection<Materia_Prima_Mongo>("Materia_Prima").FindAll().ToList();
            return View(materiaPrimaDetails);
        }

        // GET: Materia_Prima_Mongo/Details/5
        public ActionResult Details(string nome)
        {
            var materiaPrimaNome = Query<Materia_Prima_Mongo>.EQ(p => p.Nome, nome.ToString());
            var materiaPrimaDetail = _dbContext._database.GetCollection<Materia_Prima_Mongo>("Materia_Prima").FindOne(materiaPrimaNome);
            return View(materiaPrimaDetail);
        }

        // GET: Materia_Prima_Mongo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Materia_Prima_Mongo/Create
        [HttpPost]
        public ActionResult Create(Materia_Prima_Mongo materia_Prima)
        {
            try
            {
                var document = _dbContext._database.GetCollection<BsonDocument>("Materia_Prima");

                document.Insert(materia_Prima);

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Ocorreu um erro desconhecido na inserção!";
                return View("Create",materia_Prima);
            }
        }

        // GET: Materia_Prima_Mongo/Edit/5
        public ActionResult Edit(string nome)
        {
            var document = _dbContext._database.GetCollection<Materia_Prima_Mongo>("Materia_Prima");

            var materiaPrimaNome = Query<Materia_Prima_Mongo>.EQ(p => p.Nome, nome.ToString());

            var materiaPrimaDetail = _dbContext._database.GetCollection<Materia_Prima_Mongo>("Materia_Prima").FindOne(materiaPrimaNome);

            return View(materiaPrimaDetail);
        }

        // POST: Materia_Prima_Mongo/Edit/5
        [HttpPost]
        public ActionResult Edit(string nome, Materia_Prima_Mongo materiaPrima)
        {
            var materiaPrimaNome = Query<Materia_Prima_Mongo>.EQ(p => p.Nome, nome.ToString());

            var collection = _dbContext._database.GetCollection<Materia_Prima_Mongo>("Materia_Prima");

            collection.Update(materiaPrimaNome, Update.Replace(materiaPrima), UpdateFlags.None);

            return RedirectToAction("Index");   
        }

        // GET: Materia_Prima_Mongo/Delete/5
        public ActionResult Delete(string nome)
        {
            var materiaPrimaNome = Query<Materia_Prima_Mongo>.EQ(p => p.Nome, nome.ToString());

            var materiaPrimaDetail = _dbContext._database.GetCollection<Materia_Prima_Mongo>("Materia_Prima").FindOne(materiaPrimaNome);

            return View(materiaPrimaDetail);
        }

        // POST: Materia_Prima_Mongo/Delete/5
        [HttpPost]
        public ActionResult Delete(string nome, Materia_Prima_Mongo materia_Prima)
        {
            var materiaPrimaNome = Query<Materia_Prima_Mongo>.EQ(p => p.Nome, nome.ToString());

            var collection = _dbContext._database.GetCollection<Materia_Prima_Mongo>("Materia_Prima");

            collection.Remove(materiaPrimaNome, RemoveFlags.Single);

            return RedirectToAction("Index");  
        }
    }
}
