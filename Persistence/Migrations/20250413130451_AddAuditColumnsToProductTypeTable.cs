using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditColumnsToProductTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "ProductTypes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ProductTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "ProductTypes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "ProductTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_CreatedById",
                table: "ProductTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_UpdatedById",
                table: "ProductTypes",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_AspNetUsers_CreatedById",
                table: "ProductTypes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_AspNetUsers_UpdatedById",
                table: "ProductTypes",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_AspNetUsers_CreatedById",
                table: "ProductTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_AspNetUsers_UpdatedById",
                table: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypes_CreatedById",
                table: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypes_UpdatedById",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "ProductTypes");
        }
    }
}
