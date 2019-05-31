using ProjetoBanco.Context;
using ProjetoBanco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace ProjetoBanco.Controllers
{
    public class BancoRelacionalController : Controller
    {
        private ProjetoBancoContext db = new ProjetoBancoContext();

        // GET: BancoNoSql
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectRelacional()
        {
            return View();
        }

        public ActionResult Arquivo()
        {
            Stopwatch relogio = new Stopwatch();
            relogio.Start();
            var query = (from produtos_finalizados in db.Produtos_Finalizados
                         join produtos in db.Produtos on produtos_finalizados.Nome equals produtos.Nome
                         join materia in db.Materia_Prima on produtos.Nome_Materia_Principal equals materia.Nome
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
            using(StreamWriter writer = new StreamWriter(@"D:\SelectResult\Select_Relacional.csv"))
            {
                writer.Write(stringBuilder);
            }

            return View("SelectRelacional");
        }

        public ActionResult Browser()
        {
            Stopwatch relogio = new Stopwatch();
            relogio.Start();
            var query = (from produtos_finalizados in db.Produtos_Finalizados
                         join produtos in db.Produtos on produtos_finalizados.Nome equals produtos.Nome
                         join materia in db.Materia_Prima on produtos.Nome_Materia_Principal equals materia.Nome
                         orderby (materia.Nome)
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


            return View(query);
        }
    }
}
