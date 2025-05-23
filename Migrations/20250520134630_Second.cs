using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hazelnut.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "ToiletPapers");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "ToiletPapers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePathLarge",
                table: "ToiletPapers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePathMedium",
                table: "ToiletPapers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePathSmall",
                table: "ToiletPapers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToiletPapers",
                table: "ToiletPapers",
                column: "ProductId");

            migrationBuilder.UpdateData(
                table: "ToiletPapers",
                keyColumn: "ProductId",
                keyValue: -3,
                columns: new[] { "ImagePath", "ImagePathLarge", "ImagePathMedium", "ImagePathSmall" },
                values: new object[] { "images/z5255387897448_58d446087449c96b41a44c4db8516e17.jpg", "images/z5255387897448_58d446087449c96b41a44c4db8516e17.jpg 500w", "images/z5255387897448_58d446087449c96b41a44c4db8516e17-400x400.jpg 400w", "images/z5255387897448_58d446087449c96b41a44c4db8516e17-100x100.jpg 100w" });

            migrationBuilder.UpdateData(
                table: "ToiletPapers",
                keyColumn: "ProductId",
                keyValue: -2,
                columns: new[] { "ImagePath", "ImagePathLarge", "ImagePathMedium", "ImagePathSmall" },
                values: new object[] { "images/z5255387897448_58d446087449c96b41a44c4db8516e17.jpg", "images/z5255387897448_58d446087449c96b41a44c4db8516e17.jpg 500w", "images/z5255387897448_58d446087449c96b41a44c4db8516e17-400x400.jpg 400w", "images/z5255387897448_58d446087449c96b41a44c4db8516e17-100x100.jpg 100w" });

            migrationBuilder.UpdateData(
                table: "ToiletPapers",
                keyColumn: "ProductId",
                keyValue: -1,
                columns: new[] { "ImagePath", "ImagePathLarge", "ImagePathMedium", "ImagePathSmall" },
                values: new object[] { "images/z5255387897448_58d446087449c96b41a44c4db8516e17.jpg", "images/z5255387897448_58d446087449c96b41a44c4db8516e17.jpg 500w", "images/z5255387897448_58d446087449c96b41a44c4db8516e17-400x400.jpg 400w", "images/z5255387897448_58d446087449c96b41a44c4db8516e17-100x100.jpg 100w" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ToiletPapers",
                table: "ToiletPapers");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "ToiletPapers");

            migrationBuilder.DropColumn(
                name: "ImagePathLarge",
                table: "ToiletPapers");

            migrationBuilder.DropColumn(
                name: "ImagePathMedium",
                table: "ToiletPapers");

            migrationBuilder.DropColumn(
                name: "ImagePathSmall",
                table: "ToiletPapers");

            migrationBuilder.RenameTable(
                name: "ToiletPapers",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");
        }
    }
}
