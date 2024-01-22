using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektSklep.Migrations
{
    /// <inheritdoc />
    public partial class init_10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductIds",
                table: "Carts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductIds",
                table: "Carts");
        }
    }
}
