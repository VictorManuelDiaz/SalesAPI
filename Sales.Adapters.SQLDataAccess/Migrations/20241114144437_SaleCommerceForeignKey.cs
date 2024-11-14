using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.Adapters.SQLDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SaleCommerceForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_sale_tb_sale_commerce_id",
                table: "tb_sale");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_sale_tb_commerce_commerce_id",
                table: "tb_sale",
                column: "commerce_id",
                principalTable: "tb_commerce",
                principalColumn: "commerce_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_sale_tb_commerce_commerce_id",
                table: "tb_sale");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_sale_tb_sale_commerce_id",
                table: "tb_sale",
                column: "commerce_id",
                principalTable: "tb_sale",
                principalColumn: "sale_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
