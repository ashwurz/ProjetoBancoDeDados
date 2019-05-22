using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBanco.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Message = "EM MANUTENÇÃO";
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Essa é uma aplicação do Grupo 4 da Matéria Banco de Dados - CC5232";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Pagina de Contato";

            return View();
        }
    }
}   