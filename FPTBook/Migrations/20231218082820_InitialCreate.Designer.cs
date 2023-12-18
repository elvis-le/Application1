﻿// <auto-generated />
using System;
using FPTBook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FPTBook.Migrations
{
    [DbContext(typeof(FptbookContext))]
    [Migration("20231218082820_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FPTBook.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AdminID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("AdminId")
                        .HasName("PK__Admin__719FE4E8E7351136");

                    b.HasIndex(new[] { "UserId" }, "UQ__Admin__1788CCADEFAB81B9")
                        .IsUnique()
                        .HasFilter("[UserID] IS NOT NULL");

                    b.ToTable("Admin", (string)null);
                });

            modelBuilder.Entity("FPTBook.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BookID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("BookDetails")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("BookNumber")
                        .HasColumnType("int");

                    b.Property<int>("BookPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(10);

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int")
                        .HasColumnName("PublisherID");

                    b.HasKey("BookId")
                        .HasName("PK__Books__3DE0C227959A7154");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("FPTBook.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CartID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"));

                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("BookID");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("CartId")
                        .HasName("PK__Cart__51BCD79749AED903");

                    b.HasIndex("BookId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Cart", (string)null);
                });

            modelBuilder.Entity("FPTBook.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId")
                        .HasName("PK__Category__19093A2B2723FC46");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("FPTBook.Models.CategoryBook", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("BookID");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.HasIndex("BookId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Category_Book", (string)null);
                });

            modelBuilder.Entity("FPTBook.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("CustomerId")
                        .HasName("PK__Customer__A4AE64B8B31A15EC");

                    b.HasIndex(new[] { "UserId" }, "UQ__Customer__1788CCAD7A01F142")
                        .IsUnique()
                        .HasFilter("[UserID] IS NOT NULL");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("FPTBook.Models.ImageBook", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BookID");

                    b.Property<string>("BookImage1")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("BookImage2")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("BookImage3")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("BookImage4")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("BookImage5")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("BookImage6")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("BookImage7")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("BookId")
                        .HasName("PK__ImageBoo__3DE0C227C60CFA89");

                    b.ToTable("ImageBooks");
                });

            modelBuilder.Entity("FPTBook.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime");

                    b.HasKey("OrderId")
                        .HasName("PK__Orders__C3905BAF8192D899");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FPTBook.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderDetailID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"));

                    b.Property<int?>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("BookID");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId")
                        .HasName("PK__OrderDet__D3B9D30C90B30C65");

                    b.HasIndex("BookId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("FPTBook.Models.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PublisherID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PublisherId"));

                    b.Property<string>("PublisherName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PublisherId")
                        .HasName("PK__Publishe__4C657E4BFCB3C06A");

                    b.ToTable("Publisher", (string)null);
                });

            modelBuilder.Entity("FPTBook.Models.StoreOwner", b =>
                {
                    b.Property<int>("StoreOwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StoreOwnerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreOwnerId"));

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("StoreOwnerId")
                        .HasName("PK__StoreOwn__071566580C014DAA");

                    b.HasIndex(new[] { "UserId" }, "UQ__StoreOwn__1788CCAD82634EEB")
                        .IsUnique()
                        .HasFilter("[UserID] IS NOT NULL");

                    b.ToTable("StoreOwners");
                });

            modelBuilder.Entity("FPTBook.Models.StoreOwnerBook", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("BookID");

                    b.Property<int>("StoreOwnerId")
                        .HasColumnType("int")
                        .HasColumnName("StoreOwnerID");

                    b.HasIndex("BookId");

                    b.HasIndex("StoreOwnerId");

                    b.ToTable("StoreOwner_Book", (string)null);
                });

            modelBuilder.Entity("FPTBook.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("UserAddress")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UserBirthday")
                        .HasColumnType("datetime");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("UserFullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("UserImage")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("UserPhone")
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("varchar(12)");

                    b.Property<int>("UserSection")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("UserSex")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("UserId")
                        .HasName("PK__Users__1788CCAC162E6F58");

                    b.HasIndex(new[] { "UserEmail" }, "UQ__Users__08638DF8FD3C4307")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FPTBook.Models.Admin", b =>
                {
                    b.HasOne("FPTBook.Models.User", "User")
                        .WithOne("Admin")
                        .HasForeignKey("FPTBook.Models.Admin", "UserId")
                        .HasConstraintName("FK__Admin__UserID__3C69FB99");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FPTBook.Models.Book", b =>
                {
                    b.HasOne("FPTBook.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .IsRequired()
                        .HasConstraintName("fk_Book_Publisher");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("FPTBook.Models.Cart", b =>
                {
                    b.HasOne("FPTBook.Models.Book", "Book")
                        .WithMany("Carts")
                        .HasForeignKey("BookId")
                        .IsRequired()
                        .HasConstraintName("fk_Cart_Book");

                    b.HasOne("FPTBook.Models.Customer", "Customer")
                        .WithMany("Carts")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("fk_Cart_Customer");

                    b.Navigation("Book");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("FPTBook.Models.CategoryBook", b =>
                {
                    b.HasOne("FPTBook.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .IsRequired()
                        .HasConstraintName("fk_Book_Category");

                    b.HasOne("FPTBook.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("fk_Category_Book");

                    b.Navigation("Book");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FPTBook.Models.Customer", b =>
                {
                    b.HasOne("FPTBook.Models.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("FPTBook.Models.Customer", "UserId")
                        .HasConstraintName("FK__Customers__UserI__403A8C7D");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FPTBook.Models.ImageBook", b =>
                {
                    b.HasOne("FPTBook.Models.Book", "Book")
                        .WithOne("ImageBook")
                        .HasForeignKey("FPTBook.Models.ImageBook", "BookId")
                        .IsRequired()
                        .HasConstraintName("fk_Book_Image");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("FPTBook.Models.Order", b =>
                {
                    b.HasOne("FPTBook.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__Orders__Customer__59063A47");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("FPTBook.Models.OrderDetail", b =>
                {
                    b.HasOne("FPTBook.Models.Book", "Book")
                        .WithMany("OrderDetails")
                        .HasForeignKey("BookId")
                        .HasConstraintName("FK__OrderDeta__BookI__5CD6CB2B");

                    b.HasOne("FPTBook.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__OrderDeta__Order__5BE2A6F2");

                    b.Navigation("Book");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FPTBook.Models.StoreOwner", b =>
                {
                    b.HasOne("FPTBook.Models.User", "User")
                        .WithOne("StoreOwner")
                        .HasForeignKey("FPTBook.Models.StoreOwner", "UserId")
                        .HasConstraintName("FK__StoreOwne__UserI__440B1D61");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FPTBook.Models.StoreOwnerBook", b =>
                {
                    b.HasOne("FPTBook.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .IsRequired()
                        .HasConstraintName("ft_Book_StoreOwner");

                    b.HasOne("FPTBook.Models.StoreOwner", "StoreOwner")
                        .WithMany()
                        .HasForeignKey("StoreOwnerId")
                        .IsRequired()
                        .HasConstraintName("fk_StoreOwner_Book");

                    b.Navigation("Book");

                    b.Navigation("StoreOwner");
                });

            modelBuilder.Entity("FPTBook.Models.Book", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("ImageBook");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("FPTBook.Models.Customer", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("FPTBook.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("FPTBook.Models.Publisher", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("FPTBook.Models.User", b =>
                {
                    b.Navigation("Admin");

                    b.Navigation("Customer");

                    b.Navigation("StoreOwner");
                });
#pragma warning restore 612, 618
        }
    }
}
