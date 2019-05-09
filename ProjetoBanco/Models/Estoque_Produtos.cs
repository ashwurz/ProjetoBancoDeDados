namespace ProjetoBanco.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Estoque_Produtos
    {
        [Key]
        public int Sequencia_Estoque { get; set; }

        public int ID_Produto { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        public int Quantidade { get; set; }

        public virtual Produtos Produtos { get; set; }
    }
}
