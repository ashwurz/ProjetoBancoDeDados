namespace ProjetoBanco.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Produtos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produtos()
        {
            //Estoque_Produtos = new HashSet<Estoque_Produtos>();
            Produtos_Finalizados = new HashSet<Produtos_Finalizados>();
        }

        //[Key]
        //[Column(Order = 0)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int ID_Produtos { get; set; }

        [Key]
        [StringLength(30)]
        public string Nome { get; set; }

        public int Tempo_Producao_Minutos { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome_Materia_Principal { get; set; }

        [Required]
        [StringLength(20)]
        public string Lucro_Producao { get; set; }

        [Required]
        public int Quantidade_Estoque { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Estoque_Produtos> Estoque_Produtos { get; set; }

        public virtual Materia_Prima Materia_Prima { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produtos_Finalizados> Produtos_Finalizados { get; set; }
    }
}
