using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBanco.Models
{
    public class SelectResult
    {
        public int Sequencia_Producao { get; set; }
        public string Nome_Produto { get; set; }

        public string Nome_Materia_Prima { get; set; }

        public string Custo_Producao { get; set; }

        public string Lucro_Producao { get; set; }
        public DateTime Data_Producao { get; set; }
    }
}