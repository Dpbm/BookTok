using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookTok.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Sale_SaleId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_SaleId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Sale",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_BookId",
                table: "Sale",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Book_BookId",
                table: "Sale",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Book_BookId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_BookId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Sale");

            migrationBuilder.AddColumn<float>(
                name: "Amount",
                table: "Sale",
                type: "decimal(10, 2)",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "SaleId",
                table: "Book",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_SaleId",
                table: "Book",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Sale_SaleId",
                table: "Book",
                column: "SaleId",
                principalTable: "Sale",
                principalColumn: "Id");
        }
    }
}
