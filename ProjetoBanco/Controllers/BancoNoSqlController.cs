using MongoDB.Driver.Linq;
using ProjetoBanco.Context;
using ProjetoBanco.Models;
using ProjetoBanco.Models.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBanco.Controllers
{
    public class BancoNoSqlController : Controller
    {
        MongoContext _dbContext;
        public BancoNoSqlController()
        {
            _dbContext = new MongoContext();
        }
        // GET: BancoNoSql
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectNoSql()
        {
            var produtos_Db = _dbContext._database.GetCollection<Produto_Mongo>("Produtos").FindAll().ToList();
            var materia_Db = _dbContext._database.GetCollection<Materia_Prima_Mongo>("Materia_Prima").FindAll().ToList();

            //List<Select_Result_Mongo> result = produtos_Db.Aggregate().ToLookup<Produto_Mongo, Materia_Prima_Mongo, Select_Result_Mongo>(materia_Db,
            //                                                                                                                             x => x.Nome_Materia_Principal,
            //                                                                                                                             x => x.Nome);

            //var query = (from produtos in produtos_Db.AsQueryable()
            //            join materia in materia_Db.AsQueryable()
            //            on produtos.Nome_Materia_Principal equals materia.Nome
            //            select new
            //            {
            //                Nome_Produto = produtos.Nome,
            //                Nome_Materia_Prima = produtos.Nome_Materia_Principal,
            //                Custo_Producao = materia.Nome,
            //                Lucro_Producao = produtos.Lucro_Producao
            //            });

            List<SelectResult> listResult = new List<SelectResult>();

            foreach(var produto in produtos_Db)
            {
                foreach(var materia in materia_Db)
                {
                    if (materia.Nome.Equals(produto.Nome_Materia_Principal))
                    {
                        SelectResult result = new SelectResult();
                        result.Nome_Produto = produto.Nome;
                        result.Nome_Materia_Prima = materia.Nome;
                        result.Custo_Producao = materia.Custo;
                        result.Lucro_Producao = produto.Lucro_Producao;
                        listResult.Add(result);
                    }
                }
            }
            

            // var teste = query.ToList();

            //List<SelectResult> listaResult = new List<SelectResult>();

            //foreach (var item in querry)
            //{
            //    SelectResult teste = new SelectResult();
            //    teste.Nome_Produto = item.Nome_Produto;
            //    teste.Nome_Materia_Prima = item.Nome_Materia_Prima;
            //    teste.Custo_Producao = item.Custo_Producao;
            //    teste.Lucro_Producao = item.Lucro_Producao;

            //    listaResult.Add(teste);
            //}

            return View(listResult);
        }

        //// GET: BancoNoSql/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: BancoNoSql/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: BancoNoSql/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: BancoNoSql/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: BancoNoSql/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: BancoNoSql/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: BancoNoSql/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
