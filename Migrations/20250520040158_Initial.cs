using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hazelnut.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Size = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<string>(type: "TEXT", nullable: false),
                    Weight = table.Column<string>(type: "TEXT", nullable: false),
                    Origin = table.Column<string>(type: "TEXT", nullable: false),
                    Producer = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Origin", "Price", "Producer", "Size", "Weight" },
                values: new object[,]
                {
                    { -3, "_", "Giấy Vệ Sinh Cuộn Lớn 700g MC", "Việt Nam", "200k/kg", "Thế Giới Giấy", "100% Bột giấy nguyên sinh cao cấp", "700g 2&3 Lớp" },
                    { -2, "_", "Giấy Vệ Sinh Cuộn Lớn 600g MC", "Việt Nam", "200k/kg", "Thế Giới Giấy", "100% Bột giấy nguyên sinh cao cấp", "600g 2&3 Lớp" },
                    { -1, "_", "Giấy Vệ Sinh Cuộn Lớn 500g MC", "Việt Nam", "200k/kg", "Thế Giới Giấy", "100% Bột giấy nguyên sinh cao cấp", "500g 2&3 Lớp" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
