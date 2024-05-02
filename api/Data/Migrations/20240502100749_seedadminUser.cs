using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.data.Migrations
{
    /// <inheritdoc />
    public partial class seedadminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c3a8ed9-ce41-49e4-8d7b-d27f93422188");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d186748-2eff-42a0-a26b-ce2a7a0551bf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "be1710e3-d689-4467-9691-ef18fdf1f4d2", null, "admin", "ADMIN" },
                    { "f25533b9-7f5d-438c-8a4b-59115c9edd3d", null, "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Country", "DOB", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "f1bbd895-2eaa-48c3-89cc-feee3f599758", 0, null, null, "434710cd-2d56-4a05-a0d5-ad466c656176", null, new DateOnly(1, 1, 1), "rosyland@gmail.com", true, "admin", null, "admin", false, null, null, "ADMIN", "AQAAAAIAAYagAAAAEMeTebGrn9lWMBEtkTKqu1MfwfAYUVJng672Y7EJS2Up+RT0Xf8Zs+yXL2uXJkbwzg==", null, false, "da0d2896-e624-49bb-bc24-81c02493993d", false, "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "be1710e3-d689-4467-9691-ef18fdf1f4d2", "f1bbd895-2eaa-48c3-89cc-feee3f599758" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f25533b9-7f5d-438c-8a4b-59115c9edd3d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "be1710e3-d689-4467-9691-ef18fdf1f4d2", "f1bbd895-2eaa-48c3-89cc-feee3f599758" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be1710e3-d689-4467-9691-ef18fdf1f4d2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1bbd895-2eaa-48c3-89cc-feee3f599758");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c3a8ed9-ce41-49e4-8d7b-d27f93422188", null, "user", "USER" },
                    { "3d186748-2eff-42a0-a26b-ce2a7a0551bf", null, "admin", "ADMIN" }
                });
        }
    }
}
