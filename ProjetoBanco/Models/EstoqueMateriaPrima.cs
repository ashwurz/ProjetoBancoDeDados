using System;
using System.Collections.Generic;

namespace ProjetoBanco.Models
{
    public partial class EstoqueMateriaPrima
    {
        public int SequenciaEstoque { get; set; }
        public int IdMateriaPrima { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }

        public virtual MateriaPrima MateriaPrima { get; set; }
    }
}
