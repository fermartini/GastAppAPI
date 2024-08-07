using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GastAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class imgengastosingresos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icono",
                table: "NombreIngresos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Icono",
                table: "NombreGastos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icono",
                table: "NombreIngresos");

            migrationBuilder.DropColumn(
                name: "Icono",
                table: "NombreGastos");
        }
    }
}
