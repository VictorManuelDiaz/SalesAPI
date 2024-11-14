using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.Adapters.SQLDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SaleHasManySaleDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_commerce_tb_state_user_id",
                table: "tb_commerce");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_sale_tb_commerce_commerce_id",
                table: "tb_sale");

            migrationBuilder.Sql("UPDATE tb_user SET role = 0 WHERE role IS NULL;");

            migrationBuilder.Sql("ALTER TABLE tb_user ALTER COLUMN role TYPE integer USING role::integer;");

            migrationBuilder.AlterColumn<int>(
                name: "role",
                table: "tb_user",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_commerce_tb_user_user_id",
                table: "tb_commerce",
                column: "user_id",
                principalTable: "tb_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_sale_tb_sale_commerce_id",
                table: "tb_sale",
                column: "commerce_id",
                principalTable: "tb_sale",
                principalColumn: "sale_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_commerce_tb_user_user_id",
                table: "tb_commerce");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_sale_tb_sale_commerce_id",
                table: "tb_sale");

            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "tb_user",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_commerce_tb_state_user_id",
                table: "tb_commerce",
                column: "user_id",
                principalTable: "tb_state",
                principalColumn: "state_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_sale_tb_commerce_commerce_id",
                table: "tb_sale",
                column: "commerce_id",
                principalTable: "tb_commerce",
                principalColumn: "commerce_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
