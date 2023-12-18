using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPTBook.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__19093A2B2723FC46", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    PublisherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Publishe__4C657E4BFCB3C06A", x => x.PublisherID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    UserFullName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    UserPassword = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    UserImage = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    UserAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserPhone = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    UserBirthday = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserSex = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    UserSection = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__1788CCAC162E6F58", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BookPrice = table.Column<int>(type: "int", nullable: false, defaultValue: 10),
                    BookNumber = table.Column<int>(type: "int", nullable: false),
                    BookDetails = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PublisherID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Books__3DE0C227959A7154", x => x.BookID);
                    table.ForeignKey(
                        name: "fk_Book_Publisher",
                        column: x => x.PublisherID,
                        principalTable: "Publisher",
                        principalColumn: "PublisherID");
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Admin__719FE4E8E7351136", x => x.AdminID);
                    table.ForeignKey(
                        name: "FK__Admin__UserID__3C69FB99",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__A4AE64B8B31A15EC", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK__Customers__UserI__403A8C7D",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "StoreOwners",
                columns: table => new
                {
                    StoreOwnerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StoreOwn__071566580C014DAA", x => x.StoreOwnerID);
                    table.ForeignKey(
                        name: "FK__StoreOwne__UserI__440B1D61",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Category_Book",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    BookID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "fk_Book_Category",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID");
                    table.ForeignKey(
                        name: "fk_Category_Book",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID");
                });

            migrationBuilder.CreateTable(
                name: "ImageBooks",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false),
                    BookImage1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    BookImage2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    BookImage3 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    BookImage4 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    BookImage5 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    BookImage6 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    BookImage7 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ImageBoo__3DE0C227C60CFA89", x => x.BookID);
                    table.ForeignKey(
                        name: "fk_Book_Image",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cart__51BCD79749AED903", x => x.CartID);
                    table.ForeignKey(
                        name: "fk_Cart_Book",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID");
                    table.ForeignKey(
                        name: "fk_Cart_Customer",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__C3905BAF8192D899", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK__Orders__Customer__59063A47",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID");
                });

            migrationBuilder.CreateTable(
                name: "StoreOwner_Book",
                columns: table => new
                {
                    StoreOwnerID = table.Column<int>(type: "int", nullable: false),
                    BookID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "fk_StoreOwner_Book",
                        column: x => x.StoreOwnerID,
                        principalTable: "StoreOwners",
                        principalColumn: "StoreOwnerID");
                    table.ForeignKey(
                        name: "ft_Book_StoreOwner",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    BookID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderDet__D3B9D30C90B30C65", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK__OrderDeta__BookI__5CD6CB2B",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID");
                    table.ForeignKey(
                        name: "FK__OrderDeta__Order__5BE2A6F2",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Admin__1788CCADEFAB81B9",
                table: "Admin",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherID",
                table: "Books",
                column: "PublisherID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_BookID",
                table: "Cart",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CustomerID",
                table: "Cart",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_Book_BookID",
                table: "Category_Book",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_Book_CategoryID",
                table: "Category_Book",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "UQ__Customer__1788CCAD7A01F142",
                table: "Customers",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_BookID",
                table: "OrderDetails",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_StoreOwner_Book_BookID",
                table: "StoreOwner_Book",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_StoreOwner_Book_StoreOwnerID",
                table: "StoreOwner_Book",
                column: "StoreOwnerID");

            migrationBuilder.CreateIndex(
                name: "UQ__StoreOwn__1788CCAD82634EEB",
                table: "StoreOwners",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__08638DF8FD3C4307",
                table: "Users",
                column: "UserEmail",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Category_Book");

            migrationBuilder.DropTable(
                name: "ImageBooks");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "StoreOwner_Book");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "StoreOwners");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
