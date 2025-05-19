using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace e_commerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoleClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "permissions", "users:read", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 2, "permissions", "users:add", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 3, "permissions", "users:update", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 4, "permissions", "roles:read", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 5, "permissions", "roles:add", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 6, "permissions", "roles:update", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 7, "permissions", "ProductTypes:read", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 8, "permissions", "ProductTypes:add", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 9, "permissions", "ProductTypes:update", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 10, "permissions", "ProductTypes:delete", "6e963a95-217b-4c06-9622-57d9cb92a41c" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
