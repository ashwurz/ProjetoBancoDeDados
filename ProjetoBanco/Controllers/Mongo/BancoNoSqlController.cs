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

namespace ProjetoBanco.Controllers.Mongo
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
            return View();
        }

        public ActionResult Arquivo()
        {
            Stopwatch relogio = new Stopwatch();

            var produtos_Db = _dbContext._database.GetCollection<Produto_Mongo>("Produtos").FindAll().ToList();
            var materia_Db = _dbContext._database.GetCollection<Materia_Prima_Mongo>("Materia_Prima").FindAll().ToList();
            var produtosFinalizados_DB = _dbContext._database.GetCollection<Produtos_Finalizados_Mongo>("Produtos_Finalizados").FindAll().ToList();

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

            return View(query);
        }
    }
}
