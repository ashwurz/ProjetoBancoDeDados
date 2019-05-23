using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBanco.Models.Mongo
{
    public class Select_Result_Mongo : Produto_Mongo
    {
        public List<Materia_Prima_Mongo> Materias_Primas { get; set; }
    }
}