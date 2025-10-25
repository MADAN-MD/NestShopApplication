using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NestShopApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e965253-3231-4dcb-82a4-a94fddf8133d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b9dccb3-35be-4eb4-b0fa-2de65d452acd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92cb3af8-204f-40cb-b82c-50f6da94d7cb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "218ad4f0-21af-4280-9547-1a8883b3de8e", null, "seller", "seller" },
                    { "26ced492-d1d0-4060-b29d-3f194af5bb90", null, "admin", "admin" },
                    { "f82e7438-6453-4369-b1e4-c438c9b5510d", null, "client", "client" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "218ad4f0-21af-4280-9547-1a8883b3de8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26ced492-d1d0-4060-b29d-3f194af5bb90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f82e7438-6453-4369-b1e4-c438c9b5510d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e965253-3231-4dcb-82a4-a94fddf8133d", null, null, "admin" },
                    { "4b9dccb3-35be-4eb4-b0fa-2de65d452acd", null, null, "client" },
                    { "92cb3af8-204f-40cb-b82c-50f6da94d7cb", null, null, "seller" }
                });
        }
    }
}
