using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hazelnut.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SmallToiletPapers",
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
                    table.PrimaryKey("PK_SmallToiletPapers", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "SmallToiletPapers",
                columns: new[] { "ProductId", "Description", "ImagePath", "ImagePathLarge", "ImagePathMedium", "ImagePathSmall", "Name", "Origin", "Price", "Producer", "Size", "Weight" },
                values: new object[,]
                {
                    { -5, "_", "images/Picture11.png", "images/Picture11.png", null, null, "Giấy vệ sinh Posy 10 cuộn 3 lớp có lõi và không lõi", "Việt Nam", "200k/kg", "Thế Giới Giấy", "_", "_" },
                    { -4, "_", "images/z5255371706902_f30db0cd5c7b7752529b437b38b1194f.jpg", "images/z5255371706902_f30db0cd5c7b7752529b437b38b1194f.jpg 666w", "images/z5255371706902_f30db0cd5c7b7752529b437b38b1194f-600x338.jpg 600w", null, "Giấy Vệ Sinh Tesla 10 Cuộn 3 Lớp", "Việt Nam", "200k/kg", "Thế Giới Giấy", "10 cuộn 3 lớp có lõi và không lõi", "800g/túi" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmallToiletPapers");
        }
    }
}
