using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjetoBanco.Models;

namespace ProjetoBanco.Context
{
    public partial class ProjetoBancoContext : DbContext
    {
        public ProjetoBancoContext()
        {
        }

        public ProjetoBancoContext(DbContextOptions<ProjetoBancoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EstoqueMateriaPrima> EstoqueMateriaPrima { get; set; }
        public virtual DbSet<EstoqueProdutos> EstoqueProdutos { get; set; }
        public virtual DbSet<MateriaPrima> MateriaPrima { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }
        public virtual DbSet<ProdutosFinalizados> ProdutosFinalizados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-8LMG6TQ9;Database=ProjetoBanco;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<EstoqueMateriaPrima>(entity =>
            {
                entity.HasKey(e => e.SequenciaEstoque);

                entity.ToTable("Estoque_Materia_Prima");

                entity.Property(e => e.SequenciaEstoque).HasColumnName("Sequencia_Estoque");

                entity.Property(e => e.IdMateriaPrima).HasColumnName("ID_Materia_Prima");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.MateriaPrima)
                    .WithMany(p => p.EstoqueMateriaPrima)
                    .HasForeignKey(d => new { d.IdMateriaPrima, d.Nome })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estoque_Materia_Prima");
            });

            modelBuilder.Entity<EstoqueProdutos>(entity =>
            {
                entity.HasKey(e => e.SequenciaEstoque);

                entity.ToTable("Estoque_Produtos");

                entity.Property(e => e.SequenciaEstoque).HasColumnName("Sequencia_Estoque");

                entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Produtos)
                    .WithMany(p => p.EstoqueProdutos)
                    .HasForeignKey(d => new { d.IdProduto, d.Nome })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estoque_Produtos");
            });

            modelBuilder.Entity<MateriaPrima>(entity =>
            {
                entity.HasKey(e => new { e.IdMateriaPrima, e.Nome });

                entity.ToTable("Materia_Prima");

                entity.Property(e => e.IdMateriaPrima).HasColumnName("ID_Materia_Prima");

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Custo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Produtos>(entity =>
            {
                entity.HasKey(e => new { e.IdProdutos, e.Nome });

                entity.Property(e => e.IdProdutos).HasColumnName("ID_Produtos");

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IdMateriaPrincipal).HasColumnName("ID_Materia_Principal");

                entity.Property(e => e.LucroProducao)
                    .IsRequired()
                    .HasColumnName("Lucro_Producao")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NomeMateriaPrincipal)
                    .IsRequired()
                    .HasColumnName("Nome_Materia_Principal")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TempoProducaoMinutos).HasColumnName("Tempo_Producao_Minutos");

                entity.HasOne(d => d.MateriaPrima)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => new { d.IdMateriaPrincipal, d.NomeMateriaPrincipal })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produtos");
            });

            modelBuilder.Entity<ProdutosFinalizados>(entity =>
            {
                entity.HasKey(e => e.SequenciaProducao);

                entity.ToTable("Produtos_Finalizados");

                entity.Property(e => e.SequenciaProducao).HasColumnName("Sequencia_Producao");

                entity.Property(e => e.DataProducao)
                    .HasColumnName("Data_Producao")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Produtos)
                    .WithMany(p => p.ProdutosFinalizados)
                    .HasForeignKey(d => new { d.IdProduto, d.Nome })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produtos_Finalizados");
            });
        }
    }
}
