using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AccountUserAddAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_AccountUser_AccountUserId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_AccountUser_AccountUserId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_AccountUser_AccountUserId",
                table: "Hotels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountUser",
                table: "AccountUser");

            migrationBuilder.RenameTable(
                name: "AccountUser",
                newName: "AccountUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountUsers",
                table: "AccountUsers",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AccountUsers",
                columns: new[] { "Id", "AccountType", "BirthDate", "Created", "Email", "Name", "Password", "Surname", "Updated" },
                values: new object[] { 1, 1, new DateOnly(2000, 1, 1), new DateTime(2024, 5, 9, 10, 2, 58, 636, DateTimeKind.Local).AddTicks(7917), "admin@hmsapp.com", "Admin", "123456789", "Admin", null });

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_AccountUsers_AccountUserId",
                table: "Cities",
                column: "AccountUserId",
                principalTable: "AccountUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_AccountUsers_AccountUserId",
                table: "Countries",
                column: "AccountUserId",
                principalTable: "AccountUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_AccountUsers_AccountUserId",
                table: "Hotels",
                column: "AccountUserId",
                principalTable: "AccountUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_AccountUsers_AccountUserId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_AccountUsers_AccountUserId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_AccountUsers_AccountUserId",
                table: "Hotels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountUsers",
                table: "AccountUsers");

            migrationBuilder.DeleteData(
                table: "AccountUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "AccountUsers",
                newName: "AccountUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountUser",
                table: "AccountUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_AccountUser_AccountUserId",
                table: "Cities",
                column: "AccountUserId",
                principalTable: "AccountUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_AccountUser_AccountUserId",
                table: "Countries",
                column: "AccountUserId",
                principalTable: "AccountUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_AccountUser_AccountUserId",
                table: "Hotels",
                column: "AccountUserId",
                principalTable: "AccountUser",
                principalColumn: "Id");
        }
    }
}
