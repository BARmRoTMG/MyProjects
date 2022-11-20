using System;
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










//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using SelaPetShop.Models.Entities;

//namespace SelaPetShop.Data;

//public partial class PetShopDbContext : DbContext
//{
//    public PetShopDbContext()
//    {
//    }

//    public PetShopDbContext(DbContextOptions<PetShopDbContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<Animal> Animals { get; set; }

//    public virtual DbSet<Category> Categories { get; set; }

//    public virtual DbSet<Comment> Comments { get; set; }

//    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SelaPetShopDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Animal>(entity =>
//        {
//            entity.HasKey(e => e.AnimalId).HasName("PK__Animals__A21A73072284C3FD");

//            entity.Property(e => e.Name).HasMaxLength(50);
//            entity.Property(e => e.Photo).HasColumnType("image");

//            entity.HasOne(d => d.Category).WithMany(p => p.Animals)
//                .HasForeignKey(d => d.CategoryId)
//                .HasConstraintName("FK_Animals_Categories");
//        });

//        modelBuilder.Entity<Category>(entity =>
//        {
//            entity.HasKey(e => e.CategoryId).HasName("PK__tmp_ms_x__19093A0B5CC3FB7F");

//            entity.Property(e => e.CategoryName).HasMaxLength(50);
//        });

//        modelBuilder.Entity<Comment>(entity =>
//        {
//            entity.HasKey(e => e.CommentId).HasName("PK__Comments__C3B4DFCA13C03AF2");

//            entity.Property(e => e.Comment1)
//                .HasMaxLength(50)
//                .HasColumnName("Comment");

//            entity.HasOne(d => d.Animal).WithMany(p => p.Comments)
//                .HasForeignKey(d => d.AnimalId)
//                .HasConstraintName("FK_Comments_Animals");
//        });

//        modelBuilder.Entity<User>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC0792397065");

//            entity.Property(e => e.Password)
//                .HasMaxLength(50)
//                .HasColumnName("password");
//            entity.Property(e => e.Username)
//                .HasMaxLength(50)
//                .HasColumnName("username");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}