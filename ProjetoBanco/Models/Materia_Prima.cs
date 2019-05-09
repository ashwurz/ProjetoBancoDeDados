namespace ProjetoBanco.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Materia_Prima
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Materia_Prima()
        {
            Estoque_Materia_Prima = new HashSet<Estoque_Materia_Prima>();
            Produtos = new HashSet<Produtos>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Materia_Prima { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string Nome { get; set; }

        [Required]
        [StringLength(20)]
        public string Custo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estoque_Materia_Prima> Estoque_Materia_Prima { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produtos> Produtos { get; set; }
    }
}
