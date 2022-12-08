using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NewPetShop.Data.Entities;

namespace NewPetShop.Data.Context;

public partial class PetShopDbContext : DbContext
{
    public PetShopDbContext()
    {
    }

    public PetShopDbContext(DbContextOptions<PetShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=SelaPetShopDatabase;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.AnimalId).HasName("PK__Animals__A21A7307ECC738C9");

            entity.HasOne(d => d.Category).WithMany(p => p.Animals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Animals_Categories");

            entity.HasOne(d => d.Image).WithMany(p => p.Animals).HasConstraintName("FK_Animals_Images");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__tmp_ms_x__19093A0B5CC3FB7F");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasOne(d => d.Animal).WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Animals");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.Property(e => e.ImageId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
