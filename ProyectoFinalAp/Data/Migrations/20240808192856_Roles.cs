using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoFinalAp.Migrations
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "admin-role-id", null, "Admin", "ADMIN" },
                    { "user-role-id", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "admin-user-id", 0, "ba0bbc53-f994-4614-8cb4-077e8530b4c1", "steven@gmail.com", true, false, null, "STEVEN@GMAIL.COM", "STEVEN@GMAIL.COM", "AQAAAAIAAYagAAAAEKSY/E24lYSC8EgR2G3s7sRMrrNmHr+36JLu0v6AOLBKbs0USGQqus+ABknOSJTU/w==", null, false, "7e7fae65-7c67-4cf0-b5f2-a3d1327af4ad", false, "steven@gmail.com" },
                    { "user-user-id", 0, "d601cad4-0e1b-4a9b-a609-cc16ed1bf028", "isaac24.coste@gmail.com", true, false, null, "ISAAC24.COSTE@GMAIL.COM", "ISAAC24.COSTE@GMAIL.COM", "AQAAAAIAAYagAAAAEDSMO5jFgDm/e2KKob9EfOmZoT/AeTvZlV2xouJOXMQnHFxubDRrHisgoHwGvaRa4Q==", null, false, "2d1c3801-f52f-46de-83bf-72cefa9c191b", false, "isaac24.coste@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "admin-role-id", "admin-user-id" },
                    { "user-role-id", "user-user-id" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "admin-role-id", "admin-user-id" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "user-user-id" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin-role-id");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user-role-id");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-user-id");
        }
    }
}
