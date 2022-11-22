﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SelaPetShop.Models.Entities;

namespace SelaPetShop.Data
{
    public partial class PetShopDbContext : DbContext
    {
        public PetShopDbContext()
        {
        }

        public PetShopDbContext(DbContextOptions<PetShopDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; } = null!;
        public virtual DbSet<AnimalCategory> AnimalCategories { get; set; } = null!;
        public virtual DbSet<AnimalImage> AnimalImages { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=SelaPetShopDatabase;Integrated Security=True;trustservercertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.Property(e => e.AnimalId).ValueGeneratedNever();
            });

            modelBuilder.Entity<AnimalCategory>(entity =>
            {
                entity.HasOne(d => d.Animal)
                    .WithMany()
                    .HasForeignKey(d => d.AnimalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnimalCategory_Animals");

                entity.HasOne(d => d.Category)
                    .WithMany()
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnimalCategory_Categories");
            });

            modelBuilder.Entity<AnimalImage>(entity =>
            {
                entity.Property(e => e.ImageId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Animal)
                    .WithMany()
                    .HasForeignKey(d => d.AnimalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnimalImage_Animals");

                entity.HasOne(d => d.Image)
                    .WithMany()
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnimalImage_Images");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.AnimalId)
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
}