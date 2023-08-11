using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartecAPI.Models;

namespace SmartecAPI;

public partial class SmartecContext : DbContext
{
    public SmartecContext()
    {
    }

    public SmartecContext(DbContextOptions<SmartecContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrinho> Carrinhos { get; set; }

    public virtual DbSet<ItensCarrinho> ItensCarrinhos { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Promocao> Promocaos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Smartec;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrinho>(entity =>
        {
            entity.HasKey(e => e.IdDoCarrinho).HasName("PK__Carrinho__1BA5793815682D50");

            entity.ToTable("Carrinho");

            entity.Property(e => e.IdDoCarrinho).HasColumnName("idDoCarrinho");
        });

        modelBuilder.Entity<ItensCarrinho>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ItensCar__3213E83F7D518C1E");

            entity.ToTable("ItensCarrinho");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdDoCarrinho).HasColumnName("idDoCarrinho");
            entity.Property(e => e.IdDoProduto).HasColumnName("idDoProduto");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");

            entity.HasOne(d => d.IdDoCarrinhoNavigation).WithMany(p => p.ItensCarrinhos)
                .HasForeignKey(d => d.IdDoCarrinho)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItensCarr__idDoC__45F365D3");

            entity.HasOne(d => d.IdDoProdutoNavigation).WithMany(p => p.ItensCarrinhos)
                .HasForeignKey(d => d.IdDoProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItensCarr__idDoP__46E78A0C");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produtos__3213E83F4FD6AE54");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Categoria)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.Descricao)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Preco)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("preco");

            entity.HasOne(d => d.IdDaPromocaoNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.IdDaPromocao)
                .HasConstraintName("FK__Produtos__IdDaPr__4316F928");
        });

        modelBuilder.Entity<Promocao>(entity =>
        {
            entity.HasKey(e => e.IdDaPromocao).HasName("PK__Promocao__892F564E91E15F54");

            entity.ToTable("Promocao");

            entity.Property(e => e.Descricao).IsUnicode(false);
            entity.Property(e => e.NomeDaPromocao)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nomeDaPromocao");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
