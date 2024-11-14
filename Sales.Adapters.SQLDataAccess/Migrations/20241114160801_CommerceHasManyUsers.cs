using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.Adapters.SQLDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CommerceHasManyUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_commerce_tb_user_user_id",
                table: "tb_commerce");

            migrationBuilder.DropIndex(
                name: "IX_tb_commerce_user_id",
                table: "tb_commerce");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "tb_commerce");

            migrationBuilder.AddColumn<Guid>(
                name: "commerce_id",
                table: "tb_user",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_commerce_id",
                table: "tb_user",
                column: "commerce_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_user_tb_commerce_commerce_id",
                table: "tb_user",
                column: "commerce_id",
                principalTable: "tb_commerce",
                principalColumn: "commerce_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_user_tb_commerce_commerce_id",
                table: "tb_user");

            migrationBuilder.DropIndex(
                name: "IX_tb_user_commerce_id",
                table: "tb_user");

            migrationBuilder.DropColumn(
                name: "commerce_id",
                table: "tb_user");

            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                table: "tb_commerce",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tb_commerce_user_id",
                table: "tb_commerce",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_commerce_tb_user_user_id",
                table: "tb_commerce",
                column: "user_id",
                principalTable: "tb_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
