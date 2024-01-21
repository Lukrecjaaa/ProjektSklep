using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektSklep.Migrations
{
    /// <inheritdoc />
    public partial class init_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "OrdersId",
                table: "Carts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_OrdersId",
                table: "Carts",
                column: "OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Orders_OrdersId",
                table: "Carts",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Orders_OrdersId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_OrdersId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "OrdersId",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
