using ProjetoBanco.Context;
using ProjetoBanco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


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

            return View(query);
        }

        public ActionResult TesteExcel()
        {


            return View("Index");
        }

        public ActionResult AdicaoDados()
        {
            Random random = new Random();

            var produtos = db.Produtos.ToList();

            int teste = 300000;

            string[] gambiarra = new string[teste];

            List<Produtos_Finalizados> teste5 = new List<Produtos_Finalizados>();

            //for(int i = 0; i < teste; i++)
            //{
            //    Produtos_Finalizados teste2 = new Produtos_Finalizados();
            //    var teste3 = random.Next(0,19);
            //    var teste4 = produtos[teste3];
            //    teste2.Sequencia_Producao = i + 1;
            //    teste2.Nome = teste4.Nome;
            //    teste2.Data_Producao = DateTime.Now;

            //    db.Produtos_Finalizados.Add(teste2);
            //    db.SaveChanges();
            //}
            int contador = 0;

            foreach(var item in gambiarra)
            {
                Produtos_Finalizados teste2 = new Produtos_Finalizados();
                var teste3 = random.Next(0, 19);
                var teste4 = produtos[teste3];
                teste2.Sequencia_Producao = 1;
                teste2.Nome = teste4.Nome;
                teste2.Data_Producao = DateTime.Now;

                teste5.Add(teste2);
                contador++;

                if (contador == 10000)
                {
                    db.Produtos_Finalizados.AddRange(teste5);

                    db.SaveChanges();

                    teste5.Clear();

                    contador = 0;

                }
            }
            


            var produtos_Finalizados = db.Produtos_Finalizados.ToList();
            return View(produtos_Finalizados);
        }

        //[HttpPost]
        //public ActionResult SelectRelacional(string gambiarra)
        //{
        //    return View("Index");
        //}

        //// GET: BancoRelacional/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: BancoRelacional/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: BancoRelacional/Create
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

        //// GET: BancoRelacional/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: BancoRelacional/Edit/5
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

        //// GET: BancoRelacional/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: BancoRelacional/Delete/5
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
