using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AccountUserInitthenUpdateOtherTablesColumnUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cities");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Controller",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Area",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Menus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AccountUserId",
                table: "Hotels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountUserId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountUserId",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_AccountUserId",
                table: "Hotels",
                column: "AccountUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_AccountUserId",
                table: "Countries",
                column: "AccountUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_AccountUserId",
                table: "Cities",
                column: "AccountUserId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "AccountUser");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_AccountUserId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Countries_AccountUserId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Cities_AccountUserId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "AccountUserId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "AccountUserId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "AccountUserId",
                table: "Cities");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Controller",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Area",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
