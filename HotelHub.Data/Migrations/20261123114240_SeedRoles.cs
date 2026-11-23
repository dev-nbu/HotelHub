using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "auth",
                table: "AspNetRoles",
                columns: new[] { "ID", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3f4d177f-147d-4787-8a83-d3c471aea4a8"), "3f4d177f-147d-4787-8a83-d3c471aea4a8", "Receptionist", "RECEPTIONIST" },
                    { new Guid("60c9d73b-b9c6-4453-8c2f-d25d5c5600fe"), "60c9d73b-b9c6-4453-8c2f-d25d5c5600fe", "Admin", "ADMIN" },
                    { new Guid("e5f11cde-1422-44b5-a281-9541a23ae14d"), "e5f11cde-1422-44b5-a281-9541a23ae14d", "Guest", "GUEST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "AspNetRoles",
                keyColumn: "ID",
                keyValue: new Guid("3f4d177f-147d-4787-8a83-d3c471aea4a8"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "AspNetRoles",
                keyColumn: "ID",
                keyValue: new Guid("60c9d73b-b9c6-4453-8c2f-d25d5c5600fe"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "AspNetRoles",
                keyColumn: "ID",
                keyValue: new Guid("e5f11cde-1422-44b5-a281-9541a23ae14d"));
        }
    }
}
