using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAp.Migrations
{
    /// <inheritdoc />
    public partial class Categorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalleGastoPresupuestos_presupuestos_PresupuestoId",
                table: "detalleGastoPresupuestos");

            migrationBuilder.DropForeignKey(
                name: "FK_presupuestos_usuarios_UsuarioId",
                table: "presupuestos");

            migrationBuilder.DropTable(
                name: "gastos");

            migrationBuilder.DropTable(
                name: "ingresos");

            migrationBuilder.DropTable(
                name: "cuentas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_presupuestos",
                table: "presupuestos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_detalleGastoPresupuestos",
                table: "detalleGastoPresupuestos");

            migrationBuilder.DropColumn(
                name: "TotalGastos",
                table: "presupuestos");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "presupuestos",
                newName: "Presupuestos");

            migrationBuilder.RenameTable(
                name: "detalleGastoPresupuestos",
                newName: "DetalleGastoPresupuestos");

            migrationBuilder.RenameIndex(
                name: "IX_presupuestos_UsuarioId",
                table: "Presupuestos",
                newName: "IX_Presupuestos_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_detalleGastoPresupuestos_PresupuestoId",
                table: "DetalleGastoPresupuestos",
                newName: "IX_DetalleGastoPresupuestos_PresupuestoId");

            migrationBuilder.AddColumn<float>(
                name: "TotalGastos",
                table: "DetalleGastoPresupuestos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Presupuestos",
                table: "Presupuestos",
                column: "PresupuestoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetalleGastoPresupuestos",
                table: "DetalleGastoPresupuestos",
                column: "DetalleGastoId");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    TransaccionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<float>(type: "real", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripción = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.TransaccionId);
                    table.ForeignKey(
                        name: "FK_Transacciones_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transacciones_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_CategoriaId",
                table: "Transacciones",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_UsuarioId",
                table: "Transacciones",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleGastoPresupuestos_Presupuestos_PresupuestoId",
                table: "DetalleGastoPresupuestos",
                column: "PresupuestoId",
                principalTable: "Presupuestos",
                principalColumn: "PresupuestoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Presupuestos_Usuarios_UsuarioId",
                table: "Presupuestos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleGastoPresupuestos_Presupuestos_PresupuestoId",
                table: "DetalleGastoPresupuestos");

            migrationBuilder.DropForeignKey(
                name: "FK_Presupuestos_Usuarios_UsuarioId",
                table: "Presupuestos");

            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Presupuestos",
                table: "Presupuestos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetalleGastoPresupuestos",
                table: "DetalleGastoPresupuestos");

            migrationBuilder.DropColumn(
                name: "TotalGastos",
                table: "DetalleGastoPresupuestos");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "usuarios");

            migrationBuilder.RenameTable(
                name: "Presupuestos",
                newName: "presupuestos");

            migrationBuilder.RenameTable(
                name: "DetalleGastoPresupuestos",
                newName: "detalleGastoPresupuestos");

            migrationBuilder.RenameIndex(
                name: "IX_Presupuestos_UsuarioId",
                table: "presupuestos",
                newName: "IX_presupuestos_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_DetalleGastoPresupuestos_PresupuestoId",
                table: "detalleGastoPresupuestos",
                newName: "IX_detalleGastoPresupuestos_PresupuestoId");

            migrationBuilder.AddColumn<float>(
                name: "TotalGastos",
                table: "presupuestos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_presupuestos",
                table: "presupuestos",
                column: "PresupuestoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detalleGastoPresupuestos",
                table: "detalleGastoPresupuestos",
                column: "DetalleGastoId");

            migrationBuilder.CreateTable(
                name: "cuentas",
                columns: table => new
                {
                    CuentaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Saldo = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuentas", x => x.CuentaId);
                    table.ForeignKey(
                        name: "FK_cuentas_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gastos",
                columns: table => new
                {
                    GastoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuentaId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gastos", x => x.GastoId);
                    table.ForeignKey(
                        name: "FK_gastos_cuentas_CuentaId",
                        column: x => x.CuentaId,
                        principalTable: "cuentas",
                        principalColumn: "CuentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ingresos",
                columns: table => new
                {
                    IngresoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuentaId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingresos", x => x.IngresoId);
                    table.ForeignKey(
                        name: "FK_ingresos_cuentas_CuentaId",
                        column: x => x.CuentaId,
                        principalTable: "cuentas",
                        principalColumn: "CuentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cuentas_UsuarioId",
                table: "cuentas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_gastos_CuentaId",
                table: "gastos",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_ingresos_CuentaId",
                table: "ingresos",
                column: "CuentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_detalleGastoPresupuestos_presupuestos_PresupuestoId",
                table: "detalleGastoPresupuestos",
                column: "PresupuestoId",
                principalTable: "presupuestos",
                principalColumn: "PresupuestoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_presupuestos_usuarios_UsuarioId",
                table: "presupuestos",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
