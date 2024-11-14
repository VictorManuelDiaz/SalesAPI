using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.Adapters.SQLDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_state",
                columns: table => new
                {
                    state_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_state", x => x.state_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_commerce",
                columns: table => new
                {
                    commerce_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    ruc = table.Column<string>(type: "text", nullable: true),
                    state_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_commerce", x => x.commerce_id);
                    table.ForeignKey(
                        name: "FK_tb_commerce_tb_state_state_id",
                        column: x => x.state_id,
                        principalTable: "tb_state",
                        principalColumn: "state_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_user",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    role = table.Column<string>(type: "text", nullable: true),
                    commerce_id = table.Column<Guid>(type: "uuid", nullable: false),
                    state_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_user", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_tb_user_tb_commerce_commerce_id",
                        column: x => x.commerce_id,
                        principalTable: "tb_commerce",
                        principalColumn: "commerce_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_user_tb_state_state_id",
                        column: x => x.state_id,
                        principalTable: "tb_state",
                        principalColumn: "state_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_sale",
                columns: table => new
                {
                    sale_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true),
                    sale_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    commerce_id = table.Column<Guid>(type: "uuid", nullable: false),
                    state_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_sale", x => x.sale_id);
                    table.ForeignKey(
                        name: "FK_tb_sale_tb_commerce_commerce_id",
                        column: x => x.commerce_id,
                        principalTable: "tb_commerce",
                        principalColumn: "commerce_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_sale_tb_state_state_id",
                        column: x => x.state_id,
                        principalTable: "tb_state",
                        principalColumn: "state_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_sale_tb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_sale_detail",
                columns: table => new
                {
                    deatil_id = table.Column<Guid>(type: "uuid", nullable: false),
                    sale_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product = table.Column<string>(type: "text", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_sale_detail", x => x.deatil_id);
                    table.ForeignKey(
                        name: "FK_tb_sale_detail_tb_sale_sale_id",
                        column: x => x.sale_id,
                        principalTable: "tb_sale",
                        principalColumn: "sale_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_commerce_state_id",
                table: "tb_commerce",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_sale_commerce_id",
                table: "tb_sale",
                column: "commerce_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_sale_state_id",
                table: "tb_sale",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_sale_user_id",
                table: "tb_sale",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_sale_detail_sale_id",
                table: "tb_sale_detail",
                column: "sale_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_commerce_id",
                table: "tb_user",
                column: "commerce_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_state_id",
                table: "tb_user",
                column: "state_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_sale_detail");

            migrationBuilder.DropTable(
                name: "tb_sale");

            migrationBuilder.DropTable(
                name: "tb_user");

            migrationBuilder.DropTable(
                name: "tb_commerce");

            migrationBuilder.DropTable(
                name: "tb_state");
        }
    }
}
