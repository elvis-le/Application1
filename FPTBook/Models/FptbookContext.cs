using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FPTBook.Models;

public partial class FptbookContext : DbContext
{
    public FptbookContext()
    {
    }

    public FptbookContext(DbContextOptions<FptbookContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryBook> CategoryBooks { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<ImageBook> ImageBooks { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<StoreOwner> StoreOwners { get; set; }

    public virtual DbSet<StoreOwnerBook> StoreOwnerBooks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ADMIN;Initial Catalog=FPTBook;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__719FE4E8E7351136");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.UserId, "UQ__Admin__1788CCADEFAB81B9").IsUnique();

            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithOne(p => p.Admin)
                .HasForeignKey<Admin>(d => d.UserId)
                .HasConstraintName("FK__Admin__UserID__3C69FB99");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Books__3DE0C227959A7154");

            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.BookDetails).HasMaxLength(1000);
            entity.Property(e => e.BookPrice).HasDefaultValue(10);
            entity.Property(e => e.BookTitle).HasMaxLength(200);
            entity.Property(e => e.PublisherId).HasColumnName("PublisherID");

            entity.HasOne(d => d.Publisher).WithMany(p => p.Books)
                .HasForeignKey(d => d.PublisherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Book_Publisher");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__51BCD79749AED903");

            entity.ToTable("Cart");

            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Number).HasDefaultValue(1);

            entity.HasOne(d => d.Book).WithMany(p => p.Carts)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Cart_Book");

            entity.HasOne(d => d.Customer).WithMany(p => p.Carts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Cart_Customer");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A2B2723FC46");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<CategoryBook>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Category_Book");

            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

            entity.HasOne(d => d.Book).WithMany()
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Book_Category");

            entity.HasOne(d => d.Category).WithMany()
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Category_Book");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8B31A15EC");

            entity.HasIndex(e => e.UserId, "UQ__Customer__1788CCAD7A01F142").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.UserId)
                .HasConstraintName("FK__Customers__UserI__403A8C7D");
        });

        modelBuilder.Entity<ImageBook>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__ImageBoo__3DE0C227C60CFA89");

            entity.Property(e => e.BookId)
                .ValueGeneratedOnAdd()
                .HasColumnName("BookID");
            entity.Property(e => e.BookImage1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BookImage2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BookImage3)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BookImage4)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BookImage5)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BookImage6)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BookImage7)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Book).WithOne(p => p.ImageBook)
                .HasForeignKey<ImageBook>(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Book_Image");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF8192D899");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__Customer__59063A47");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30C90B30C65");

            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.HasOne(d => d.Book).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__OrderDeta__BookI__5CD6CB2B");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__Order__5BE2A6F2");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.PublisherId).HasName("PK__Publishe__4C657E4BFCB3C06A");

            entity.ToTable("Publisher");

            entity.Property(e => e.PublisherId).HasColumnName("PublisherID");
            entity.Property(e => e.PublisherName).HasMaxLength(50);
        });

        modelBuilder.Entity<StoreOwner>(entity =>
        {
            entity.HasKey(e => e.StoreOwnerId).HasName("PK__StoreOwn__071566580C014DAA");

            entity.HasIndex(e => e.UserId, "UQ__StoreOwn__1788CCAD82634EEB").IsUnique();

            entity.Property(e => e.StoreOwnerId).HasColumnName("StoreOwnerID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithOne(p => p.StoreOwner)
                .HasForeignKey<StoreOwner>(d => d.UserId)
                .HasConstraintName("FK__StoreOwne__UserI__440B1D61");
        });

        modelBuilder.Entity<StoreOwnerBook>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("StoreOwner_Book");

            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.StoreOwnerId).HasColumnName("StoreOwnerID");

            entity.HasOne(d => d.Book).WithMany()
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ft_Book_StoreOwner");

            entity.HasOne(d => d.StoreOwner).WithMany()
                .HasForeignKey(d => d.StoreOwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_StoreOwner_Book");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC162E6F58");

            entity.HasIndex(e => e.UserEmail, "UQ__Users__08638DF8FD3C4307").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserAddress).HasMaxLength(100);
            entity.Property(e => e.UserBirthday).HasColumnType("datetime");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserFullName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserImage)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserPhone)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.UserSection).HasDefaultValue(1);
            entity.Property(e => e.UserSex)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
