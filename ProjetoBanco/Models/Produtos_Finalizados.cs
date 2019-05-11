namespace ProjetoBanco.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Produtos_Finalizados
    {
        [Key]
        public int Sequencia_Producao { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        public DateTime Data_Producao { get; set; }

        public virtual Produtos Produtos { get; set; }
    }
}
