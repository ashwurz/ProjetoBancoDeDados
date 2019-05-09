namespace ProjetoBanco.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ProjetoBanco.Models;

    public partial class ProjetoBancoContext : DbContext
    {
        public ProjetoBancoContext()
            : base("name=ProjetoBancoContext")
        {
        }

        public virtual DbSet<Estoque_Materia_Prima> Estoque_Materia_Prima { get; set; }
        public virtual DbSet<Estoque_Produtos> Estoque_Produtos { get; set; }
        public virtual DbSet<Materia_Prima> Materia_Prima { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }
        public virtual DbSet<Produtos_Finalizados> Produtos_Finalizados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estoque_Materia_Prima>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Estoque_Produtos>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Materia_Prima>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Materia_Prima>()
                .Property(e => e.Custo)
                .IsUnicode(false);

            modelBuilder.Entity<Materia_Prima>()
                .HasMany(e => e.Estoque_Materia_Prima)
                .WithRequired(e => e.Materia_Prima)
                .HasForeignKey(e => new { e.ID_Materia_Prima, e.Nome })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Materia_Prima>()
                .HasMany(e => e.Produtos)
                .WithRequired(e => e.Materia_Prima)
                .HasForeignKey(e => new { e.ID_Materia_Principal, e.Nome_Materia_Principal })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produtos>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Produtos>()
                .Property(e => e.Nome_Materia_Principal)
                .IsUnicode(false);

            modelBuilder.Entity<Produtos>()
                .Property(e => e.Lucro_Producao)
                .IsUnicode(false);

            modelBuilder.Entity<Produtos>()
                .HasMany(e => e.Estoque_Produtos)
                .WithRequired(e => e.Produtos)
                .HasForeignKey(e => new { e.ID_Produto, e.Nome })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produtos>()
                .HasMany(e => e.Produtos_Finalizados)
                .WithRequired(e => e.Produtos)
                .HasForeignKey(e => new { e.ID_Produto, e.Nome })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produtos_Finalizados>()
                .Property(e => e.Nome)
                .IsUnicode(false);
        }
    }
}
