using System;
using System.Collections.Generic;

namespace ProjetoBanco.Models
{
    public partial class MateriaPrima
    {
        public MateriaPrima()
        {
            EstoqueMateriaPrima = new HashSet<EstoqueMateriaPrima>();
            Produtos = new HashSet<Produtos>();
        }

        public int IdMateriaPrima { get; set; }
        public string Nome { get; set; }
        public string Custo { get; set; }

        public virtual ICollection<EstoqueMateriaPrima> EstoqueMateriaPrima { get; set; }
        public virtual ICollection<Produtos> Produtos { get; set; }
    }
}
