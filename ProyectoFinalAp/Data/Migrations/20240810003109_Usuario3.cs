using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAp.Migrations
{
    /// <inheritdoc />
    public partial class Usuario3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presupuestos_Usuarios_UsuarioId",
                table: "Presupuestos");

            migrationBuilder.DropIndex(
                name: "IX_Presupuestos_UsuarioId",
                table: "Presupuestos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Presupuestos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Presupuestos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presupuestos_UsuarioId",
                table: "Presupuestos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Presupuestos_Usuarios_UsuarioId",
                table: "Presupuestos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId");
        }
    }
}
