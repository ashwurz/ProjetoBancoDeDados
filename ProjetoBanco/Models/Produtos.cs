using System;
using System.Collections.Generic;

namespace ProjetoBanco.Models
{
    public partial class Produtos
    {
        public Produtos()
        {
            EstoqueProdutos = new HashSet<EstoqueProdutos>();
            ProdutosFinalizados = new HashSet<ProdutosFinalizados>();
        }

        public int IdProdutos { get; set; }
        public string Nome { get; set; }
        public int TempoProducaoMinutos { get; set; }
        public int IdMateriaPrincipal { get; set; }
        public string NomeMateriaPrincipal { get; set; }
        public string LucroProducao { get; set; }

        public virtual MateriaPrima MateriaPrima { get; set; }
        public virtual ICollection<EstoqueProdutos> EstoqueProdutos { get; set; }
        public virtual ICollection<ProdutosFinalizados> ProdutosFinalizados { get; set; }
    }
}
