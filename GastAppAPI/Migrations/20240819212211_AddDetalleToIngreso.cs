using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GastAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDetalleToIngreso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Detalle",
                table: "Ingresos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detalle",
                table: "Ingresos");
        }
    }
}
