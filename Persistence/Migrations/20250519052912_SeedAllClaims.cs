using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace e_commerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedAllClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "permissions", "ProductTypes:read", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 2, "permissions", "ProductTypes:add", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 3, "permissions", "ProductTypes:update", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 4, "permissions", "ProductTypes:delete", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 5, "permissions", "carts:read", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 6, "permissions", "carts:add", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 7, "permissions", "carts:update", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 8, "permissions", "carts:delete", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 9, "permissions", "orders:read", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 10, "permissions", "orders:add", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 11, "permissions", "orders:update", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 12, "permissions", "payments:add", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 13, "permissions", "payments:webhook", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 14, "permissions", "products:read", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 15, "permissions", "products:add", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 16, "permissions", "products:update", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 17, "permissions", "reviews:read", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 18, "permissions", "reviews:add", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 19, "permissions", "reviews:update", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 20, "permissions", "reviews:delete", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 21, "permissions", "wishlists:read", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 22, "permissions", "wishlists:add", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 23, "permissions", "wishlists:delete", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 24, "permissions", "users:read", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 25, "permissions", "users:add", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 26, "permissions", "users:update", "6e963a95-217b-4c06-9622-57d9cb92a41c" }
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

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 26);
        }
    }
}
