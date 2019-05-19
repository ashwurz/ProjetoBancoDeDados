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
            var query = (from produtos in db.Produtos
                          join materia in db.Materia_Prima
                          on produtos.Nome_Materia_Principal equals materia.Nome
                          select new SelectResult
                          {
                              Nome_Produto = produtos.Nome,
                              Nome_Materia_Prima = produtos.Nome_Materia_Principal,
                              Custo_Producao = materia.Custo,
                              Lucro_Producao = produtos.Lucro_Producao
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
