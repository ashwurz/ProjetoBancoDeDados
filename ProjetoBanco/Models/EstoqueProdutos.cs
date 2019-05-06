using System;
using System.Collections.Generic;

namespace ProjetoBanco.Models
{
    public partial class EstoqueProdutos
    {
        public int SequenciaEstoque { get; set; }
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }

        public virtual Produtos Produtos { get; set; }
    }
}
