using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektSklep.Migrations
{
    /// <inheritdoc />
    public partial class init_9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Sum",
                table: "Carts",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sum",
                table: "Carts");
        }
    }
}
