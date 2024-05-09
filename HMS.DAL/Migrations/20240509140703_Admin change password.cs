using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Adminchangepassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccountUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Password" },
                values: new object[] { new DateTime(2024, 5, 9, 17, 7, 2, 23, DateTimeKind.Local).AddTicks(6435), "733eda24b9c7f1c931ca7682c614a2ba" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccountUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Password" },
                values: new object[] { new DateTime(2024, 5, 9, 10, 52, 31, 565, DateTimeKind.Local).AddTicks(8400), "25f9e794323b453885f5181f1b624d0b" });
        }
    }
}
