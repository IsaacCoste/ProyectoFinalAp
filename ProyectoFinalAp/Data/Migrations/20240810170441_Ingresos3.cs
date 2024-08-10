using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAp.Migrations
{
    /// <inheritdoc />
    public partial class Ingresos3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingresos_Categorias_CategoriasCategoriaId",
                table: "Ingresos");

            migrationBuilder.DropIndex(
                name: "IX_Ingresos_CategoriasCategoriaId",
                table: "Ingresos");

            migrationBuilder.DropColumn(
                name: "CategoriasCategoriaId",
                table: "Ingresos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriasCategoriaId",
                table: "Ingresos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_CategoriasCategoriaId",
                table: "Ingresos",
                column: "CategoriasCategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresos_Categorias_CategoriasCategoriaId",
                table: "Ingresos",
                column: "CategoriasCategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId");
        }
    }
}
