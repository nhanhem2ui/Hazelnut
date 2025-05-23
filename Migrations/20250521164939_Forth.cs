using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hazelnut.Migrations
{
    /// <inheritdoc />
    public partial class Forth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Napkins",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Size = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<string>(type: "TEXT", nullable: false),
                    Weight = table.Column<string>(type: "TEXT", nullable: false),
                    Origin = table.Column<string>(type: "TEXT", nullable: false),
                    Producer = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePathSmall = table.Column<string>(type: "TEXT", nullable: true),
                    ImagePathMedium = table.Column<string>(type: "TEXT", nullable: true),
                    ImagePathLarge = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Napkins", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "PaperContainers",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Size = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<string>(type: "TEXT", nullable: false),
                    Weight = table.Column<string>(type: "TEXT", nullable: false),
                    Origin = table.Column<string>(type: "TEXT", nullable: false),
                    Producer = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePathSmall = table.Column<string>(type: "TEXT", nullable: true),
                    ImagePathMedium = table.Column<string>(type: "TEXT", nullable: true),
                    ImagePathLarge = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperContainers", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "PaperHandkerchiefs",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Size = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<string>(type: "TEXT", nullable: false),
                    Weight = table.Column<string>(type: "TEXT", nullable: false),
                    Origin = table.Column<string>(type: "TEXT", nullable: false),
                    Producer = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePathSmall = table.Column<string>(type: "TEXT", nullable: true),
                    ImagePathMedium = table.Column<string>(type: "TEXT", nullable: true),
                    ImagePathLarge = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperHandkerchiefs", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Napkins",
                columns: new[] { "ProductId", "Description", "ImagePath", "ImagePathLarge", "ImagePathMedium", "ImagePathSmall", "Name", "Origin", "Price", "Producer", "Size", "Weight" },
                values: new object[,]
                {
                    { -7, "_", "images/Picture15.png", "images/Picture15.png", null, null, "Giấy Lụa Rút Cata", "Việt Nam", "200k/kg", "Thế Giới Giấy", "200mm x 185mm", "280 tờ/ túi x 2 lớp" },
                    { -6, "_", "images/Picture16.png", "images/Picture16.png 349w", null, "images/Picture16-100x100.png 100w", "Giấy Lụa Rút Posy 120 Tờ 3 lớp Cao Cấp", "Posy Việt Nam", "200k/kg", "Thế Giới Giấy", "198mm × 200 mm", "180 Tờ 3 lớp" }
                });

            migrationBuilder.InsertData(
                table: "PaperContainers",
                columns: new[] { "ProductId", "Description", "ImagePath", "ImagePathLarge", "ImagePathMedium", "ImagePathSmall", "Name", "Origin", "Price", "Producer", "Size", "Weight" },
                values: new object[,]
                {
                    { -11, "_", "images/z5270723986943_6e8a877ec9d8f31c134b0c0d28e49651.jpg", "images/z5270723986943_6e8a877ec9d8f31c134b0c0d28e49651.jpg", null, null, "Hộp Đựng Giấy Lau Tay Inox", "Việt Nam", "200k/kg", "Thế Giới Giấy", "Inox 304 Cao Cấp", "_" },
                    { -10, "_", "images/Picture10.png", "images/Picture10.png", null, null, "Hộp Đựng Giấy Lau Tay Nhựa", "Posy Việt Nam", "200k/kg", "Thế Giới Giấy", "_", "_" }
                });

            migrationBuilder.InsertData(
                table: "PaperHandkerchiefs",
                columns: new[] { "ProductId", "Description", "ImagePath", "ImagePathLarge", "ImagePathMedium", "ImagePathSmall", "Name", "Origin", "Price", "Producer", "Size", "Weight" },
                values: new object[,]
                {
                    { -9, "_", "images/Picture6.png", "images/Picture6.png", null, null, "Giấy Lụa Rút Cata", "Việt Nam", "200k/kg", "Thế Giới Giấy", "190mm x 220mm", "100 Tờ 2 Lớp" },
                    { -8, "_", "images/Picture7.png", "images/Picture7.png", null, null, "Giấy Lau Tay Đa Năng Posy", "Posy Việt Nam", "200k/kg", "Thế Giới Giấy", "190mm x 220mm", "100 Tờ 2 Lớp Gấp 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Napkins");

            migrationBuilder.DropTable(
                name: "PaperContainers");

            migrationBuilder.DropTable(
                name: "PaperHandkerchiefs");
        }
    }
}
