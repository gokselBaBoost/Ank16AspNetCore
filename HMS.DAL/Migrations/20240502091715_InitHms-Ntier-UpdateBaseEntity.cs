using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitHmsNtierUpdateBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Hotels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Countries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Cities",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Cities");
        }
    }
}
