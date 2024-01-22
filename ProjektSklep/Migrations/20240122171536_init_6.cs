using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektSklep.Migrations
{
    /// <inheritdoc />
    public partial class init_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOrdered",
                table: "Carts",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOrdered",
                table: "Carts");
        }
    }
}
