using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai_Pizzarias_extra_WebApi.Domains
{
    public partial class PizzariasFsContext : DbContext
    {
        public PizzariasFsContext()
        {
        }

        public PizzariasFsContext(DbContextOptions<PizzariasFsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Credenciais> Credenciais { get; set; }
        public virtual DbSet<Pizzarias> Pizzarias { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog= PIZZARIAS_FS; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.ToTable("CATEGORIAS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasColumnName("CATEGORIA")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Credenciais>(entity =>
            {
                entity.ToTable("CREDENCIAIS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Credencial)
                    .IsRequired()
                    .HasColumnName("CREDENCIAL")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pizzarias>(entity =>
            {
                entity.ToTable("PIZZARIAS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasColumnName("ENDERECO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Numero).HasColumnName("NUMERO");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("TELEFONE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Vegana).HasColumnName("VEGANA");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Pizzarias)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__PIZZARIAS__ID_CA__534D60F1");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIOS__161CF724452D6B02")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdCredencial)
                    .HasColumnName("ID_CREDENCIAL")
                    .HasDefaultValueSql("((2))");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCredencialNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdCredencial)
                    .HasConstraintName("FK__USUARIOS__ID_CRE__4CA06362");
            });
        }
    }
}
