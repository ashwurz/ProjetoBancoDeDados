using MongoDB.Driver.Linq;
using ProjetoBanco.Context;
using ProjetoBanco.Models;
using ProjetoBanco.Models.Mongo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBanco.Controllers
{
    public class BancoNoSqlController : Controller
    {
        //private ProjetoBancoContext dbRelacional = new ProjetoBancoContext();

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
            return View();
        }

        public ActionResult Arquivo()
        {
            Stopwatch relogio = new Stopwatch();

            var produtos_Db = _dbContext._database.GetCollection<Produto_Mongo>("Produtos").FindAll().ToList();
            var materia_Db = _dbContext._database.GetCollection<Materia_Prima_Mongo>("Materia_Prima").FindAll().ToList();
            var produtosFinalizados_DB = _dbContext._database.GetCollection<Produtos_Finalizados_Mongo>("Produtos_Finalizados").FindAll().ToList();

            //List<SelectResult> listResult = new List<SelectResult>();
            //foreach (var produtosFinalizados in produtosFinalizados_DB)
            //{
            //    foreach (var produtos in produtos_Db)
            //    {
            //        if (produtos.Nome.Equals(produtosFinalizados.Nome))
            //        {
            //            foreach (var materia in materia_Db)
            //            {
            //                if (materia.Nome.Equals(produtos.Nome_Materia_Principal))
            //                {
            //                    SelectResult result = new SelectResult();
            //                    result.Sequencia_Producao = produtosFinalizados.Sequencia_Producao;
            //                    result.Nome_Produto = produtos.Nome;
            //                    result.Nome_Materia_Prima = materia.Nome;
            //                    result.Custo_Producao = materia.Custo;
            //                    result.Lucro_Producao = produtos.Lucro_Producao;
            //                    result.Data_Producao = produtosFinalizados.Data_Producao;
            //                    listResult.Add(result);
            //                }
            //            }
            //        }
            //    }
            //}
            relogio.Start();
            var query = (from produtos_finalizados in produtosFinalizados_DB.AsQueryable()
                         join produtos in produtos_Db.AsQueryable() on produtos_finalizados.Nome equals produtos.Nome
                         join materia in materia_Db.AsQueryable() on produtos.Nome_Materia_Principal equals materia.Nome
                         select new SelectResult
                         {
                             Sequencia_Producao = produtos_finalizados.Sequencia_Producao,
                             Nome_Produto = produtos.Nome,
                             Nome_Materia_Prima = produtos.Nome_Materia_Principal,
                             Custo_Producao = materia.Custo,
                             Lucro_Producao = produtos.Lucro_Producao,
                             Data_Producao = produtos_finalizados.Data_Producao
                         }).ToList();
            relogio.Stop();

            ViewBag.Relogio = relogio.Elapsed;

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Sequencia_Producao;");
            stringBuilder.Append("Nome_Produto;");
            stringBuilder.Append("Nome_Materia_Prima;");
            stringBuilder.Append("Custo_Producao;");
            stringBuilder.Append("Lucro_Producao;");
            stringBuilder.Append("Data_Producao;");
            stringBuilder.Append(Environment.NewLine);

            for (int i = 0; i < query.Count(); i++)
            {
                stringBuilder.Append(query[i].Sequencia_Producao.ToString() + ";");
                stringBuilder.Append(query[i].Nome_Produto + ";");
                stringBuilder.Append(query[i].Nome_Materia_Prima + ";");
                stringBuilder.Append(query[i].Custo_Producao + ";");
                stringBuilder.Append(query[i].Lucro_Producao + ";");
                stringBuilder.Append(query[i].Data_Producao.ToString() + ";");
                stringBuilder.Append(Environment.NewLine);
            }

            using (StreamWriter writer = new StreamWriter(@"D:\SelectResult\Select_NoSQL.csv"))
            {
                writer.Write(stringBuilder);
            }


            return View("SelectNoSql");
        }

        public ActionResult Browser()
        {
            var produtos_Db = _dbContext._database.GetCollection<Produto_Mongo>("Produtos").FindAll().ToList();
            var materia_Db = _dbContext._database.GetCollection<Materia_Prima_Mongo>("Materia_Prima").FindAll().ToList();
            var produtosFinalizados_DB = _dbContext._database.GetCollection<Produtos_Finalizados_Mongo>("Produtos_Finalizados").FindAll().ToList();

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
            
            foreach(var produtosFinalizados in produtosFinalizados_DB)
            {
                foreach(var produtos in produtos_Db)
                {
                    if (produtos.Nome.Equals(produtosFinalizados.Nome))
                    {
                        foreach(var materia in materia_Db)
                        {
                            if (materia.Nome.Equals(produtos.Nome_Materia_Principal))
                            {
                                SelectResult result = new SelectResult();
                                result.Sequencia_Producao = produtosFinalizados.Sequencia_Producao;
                                result.Nome_Produto = produtos.Nome;
                                result.Nome_Materia_Prima = materia.Nome;
                                result.Custo_Producao = materia.Custo;
                                result.Lucro_Producao = produtos.Lucro_Producao;
                                result.Data_Producao = produtosFinalizados.Data_Producao;
                                listResult.Add(result);
                            }
                        }
                    }
                }
            }

            return View(listResult);
        }

        //public ActionResult Adicao()
        //{
        //    var produtos_Finalizados = dbRelacional.Produtos_Finalizados.ToList();

        //    var document = _dbContext._database.GetCollection<Produtos_Finalizados_Mongo>("Produtos_Finalizados");



        //    foreach(var item in produtos_Finalizados)
        //    {
        //        Produtos_Finalizados_Mongo teste = new Produtos_Finalizados_Mongo();
        //        teste.Sequencia_Producao = item.Sequencia_Producao;
        //        teste.Nome = item.Nome;
        //        teste.Data_Producao = item.Data_Producao;

                
        //        document.Insert(teste);
        //    }

        //    return View();
        //}

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
