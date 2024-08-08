using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAp.Migrations
{
    /// <inheritdoc />
    public partial class Actualizando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalGastos",
                table: "DetalleGastoPresupuestos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "TotalGastos",
                table: "DetalleGastoPresupuestos",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
