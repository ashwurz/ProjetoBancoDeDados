namespace ProjetoBanco.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Estoque_Materia_Prima
    {
        [Key]
        public int Sequencia_Estoque { get; set; }

        public int ID_Materia_Prima { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        public int Quantidade { get; set; }

        public virtual Materia_Prima Materia_Prima { get; set; }
    }
}
