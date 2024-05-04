using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EastsydApp.API.Data.EDMigrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Qty = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    IconCss = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ImageURL = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Qty = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "IconCss", "Name" },
                values: new object[,]
                {
                    { 1, "fa-solid fa-pump-soap", "Beauty" },
                    { 2, "fa-solid fa-couch", "Furniture" },
                    { 3, "fa-solid fa-plug", "Electronics" },
                    { 4, "fa-solid fa-shoe-prints", "Shoes" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[,]
                {
                    { 1, "Bob" },
                    { 2, "Sarah" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageURL", "Name", "Price", "ProductCategoryId", "Qty" },
                values: new object[,]
                {
                    { 1, "A kit provided by Glossier, containing skin care, hair care and makeup products", "/Images/Skin-Care/Beauty Kit.jpg", "Glossier - Beauty Kit", 100m, 1, 100 },
                    { 2, "A kit provided by Curology, containing skin care products", "/Images/Skin-Care/elfBeauty.jpg", "elf - Make Up Kit", 50m, 1, 45 },
                    { 3, "Brown Powder by MAC", "/Images/Skin-Care/Mc Beauty.jpg", "Mac  Foundation Powder", 30m, 1, 85 },
                    { 4, "A kit provided by Curology, it makes ypur lip pop and stand out", "/Images/Skin-Care/Lip Gloss two.jpg", "Rare Beauty Lip Gloss", 20m, 1, 30 },
                    { 5, "A kit provided by Schwarzkopf, it makes ypur lip pop and stand out", "/Images/Skin-Care/Lip Stick.jpg", "Lip Glow", 50m, 1, 60 },
                    { 6, "Air Pods - in-ear wireless headphones", "/Images/Electronics/Airpod 3.jpg", "Apple Air Pod", 100m, 3, 120 },
                    { 7, "Airpods  3 ", "/Images/Electronics/Airpod and pack.jpg", "Airpod & Pack", 40m, 3, 200 },
                    { 8, "On-ear Black Headphones - Beats by Dr Dre", "/Images/Electronics/Beats Headphone.jpg", "Beats Headphones", 40m, 3, 300 },
                    { 9, "Black Tozo Headbuds", "/Images/Electronics/Tozo Earbud.jpg", "Tozo buds", 600m, 3, 20 },
                    { 10, "Tripod", "/Images/Electronics/Tripod.jpg", "Tripod", 500m, 3, 15 },
                    { 11, "Black Iphone 11 Pro", "/Images/Electronics/Iphone.jpg", "Iphone 11", 100m, 3, 60 },
                    { 12, "Very comfortable black chair", "/Images/Furniture/bigChair.jpg", "Black Big Chair", 50m, 2, 212 },
                    { 13, "Very comfortable pink and black leather gaming chair", "/Images/Furniture/chair 2.jpg", "Black and Pink Gaming Chair", 50m, 2, 112 },
                    { 14, "Very comfortable lounge chair", "/Images/Furniture/chair one.jpg", "Lounge Chair", 70m, 2, 90 },
                    { 15, "Office Table Lamp", "/Images/Furniture/Lamp.jpg", "Solid Lamp", 20m, 2, 73 },
                    { 16, "Very comfortable office desk", "/Images/Furniture/Desk.jpg", "Desk", 70m, 2, 90 },
                    { 17, "Ash family chairs, full set.", "/Images/Furniture/family chair.jpg", "Full set Sofa", 15m, 2, 100 },
                    { 18, "Comfortable addidas Sneakers in most sizes", "/Images/Shoes/Addidas.jpg", "Addidas Sneakers", 100m, 4, 50 },
                    { 19, "Brown Chelsea Boots  - available in most sizes", "/Images/Shoes/Chelsea Boot.jpg", "Chelsea Boot", 150m, 4, 60 },
                    { 20, " Nike Air Max - available in most sizes", "/Images/Shoes/Nike Air Max.jpg", " Nike Air Max", 200m, 4, 70 },
                    { 21, "Nike Dunk Low - available in most sizes", "/Images/Shoes/Nike Dunk Low.jpg", "Nike Dunk Low", 120m, 4, 120 },
                    { 22, "Addidas  Busekitz - available in most sizes", "/Images/Shoes/Puma.jpg", "Addidas  Busekitz", 200m, 4, 100 },
                    { 23, "Sketchers Trainers - available in most sizes", "/Images/Shoes/Sketchers.jpg", "Sketchers Trainers", 50m, 4, 150 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
