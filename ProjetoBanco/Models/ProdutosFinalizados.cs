using System;
using System.Collections.Generic;

namespace ProjetoBanco.Models
{
    public partial class ProdutosFinalizados
    {
        public int SequenciaProducao { get; set; }
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public DateTime DataProducao { get; set; }

        public virtual Produtos Produtos { get; set; }
    }
}
