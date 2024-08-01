using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAp.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RolId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "cuentas",
                columns: table => new
                {
                    CuentaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Saldo = table.Column<float>(type: "real", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "presupuestos",
                columns: table => new
                {
                    PresupuestoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontoAsignado = table.Column<float>(type: "real", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalGastos = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_presupuestos", x => x.PresupuestoId);
                    table.ForeignKey(
                        name: "FK_presupuestos_usuarios_UsuarioId",
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
                    Monto = table.Column<float>(type: "real", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Monto = table.Column<float>(type: "real", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "detalleGastoPresupuestos",
                columns: table => new
                {
                    DetalleGastoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PresupuestoId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monto = table.Column<float>(type: "real", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleGastoPresupuestos", x => x.DetalleGastoId);
                    table.ForeignKey(
                        name: "FK_detalleGastoPresupuestos_presupuestos_PresupuestoId",
                        column: x => x.PresupuestoId,
                        principalTable: "presupuestos",
                        principalColumn: "PresupuestoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cuentas_UsuarioId",
                table: "cuentas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleGastoPresupuestos_PresupuestoId",
                table: "detalleGastoPresupuestos",
                column: "PresupuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_gastos_CuentaId",
                table: "gastos",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_ingresos_CuentaId",
                table: "ingresos",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_presupuestos_UsuarioId",
                table: "presupuestos",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalleGastoPresupuestos");

            migrationBuilder.DropTable(
                name: "gastos");

            migrationBuilder.DropTable(
                name: "ingresos");

            migrationBuilder.DropTable(
                name: "presupuestos");

            migrationBuilder.DropTable(
                name: "cuentas");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
