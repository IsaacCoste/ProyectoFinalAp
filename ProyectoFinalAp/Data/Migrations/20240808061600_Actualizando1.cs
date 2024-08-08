using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAp.Migrations
{
    /// <inheritdoc />
    public partial class Actualizando1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presupuestos_Usuarios_UsuarioId",
                table: "Presupuestos");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Presupuestos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Presupuestos_Usuarios_UsuarioId",
                table: "Presupuestos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presupuestos_Usuarios_UsuarioId",
                table: "Presupuestos");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Presupuestos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Presupuestos_Usuarios_UsuarioId",
                table: "Presupuestos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
