using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestionInventario.Models;

public partial class GestionInventariosContext : DbContext
{
    public GestionInventariosContext()
    {
    }

    public GestionInventariosContext(DbContextOptions<GestionInventariosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ajuste> Ajustes { get; set; }

    public virtual DbSet<Almacen> Almacens { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Entradum> Entrada { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Salidum> Salida { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=EPAYANO;Database=GestionInventarios;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ajuste>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ajuste__3213E83F391B0EE8");

            entity.ToTable("Ajuste");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdAlmacen).HasColumnName("id_almacen");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Motivo)
                .HasColumnType("text")
                .HasColumnName("motivo");
            entity.Property(e => e.Tipo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdAlmacenNavigation).WithMany(p => p.Ajustes)
                .HasForeignKey(d => d.IdAlmacen)
                .HasConstraintName("FK__Ajuste__id_almac__4E88ABD4");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Ajustes)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__Ajuste__id_produ__4D94879B");
        });

        modelBuilder.Entity<Almacen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Almacen__3213E83F3BAEA390");

            entity.ToTable("Almacen");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3213E83FE17FBEF7");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Entradum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Entrada__3213E83F3D86FD45");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdAlmacen).HasColumnName("id_almacen");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");

            entity.HasOne(d => d.IdAlmacenNavigation).WithMany(p => p.Entrada)
                .HasForeignKey(d => d.IdAlmacen)
                .HasConstraintName("FK__Entrada__id_alma__46E78A0C");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Entrada)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__Entrada__id_prod__45F365D3");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inventar__3213E83F6FF81F6D");

            entity.ToTable("Inventario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CantidadActual).HasColumnName("cantidad_actual");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdAlmacen).HasColumnName("id_almacen");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");

            entity.HasOne(d => d.IdAlmacenNavigation).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.IdAlmacen)
                .HasConstraintName("FK__Inventari__id_al__52593CB8");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__Inventari__id_pr__5165187F");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3213E83F4BC45669");

            entity.ToTable("Producto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Producto__id_cat__412EB0B6");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__Producto__id_pro__403A8C7D");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proveedo__3213E83FA1CD6826");

            entity.ToTable("Proveedor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contacto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contacto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Salidum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Salida__3213E83FBC425886");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdAlmacen).HasColumnName("id_almacen");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");

            entity.HasOne(d => d.IdAlmacenNavigation).WithMany(p => p.Salida)
                .HasForeignKey(d => d.IdAlmacen)
                .HasConstraintName("FK__Salida__id_almac__4AB81AF0");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Salida)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__Salida__id_produ__49C3F6B7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
