using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Identityadminchangepassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "355bc4a6-465a-4154-a1b8-1a1bdf2d86da", "36882a8b-7718-411d-aa72-cf0ff723c15e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "355bc4a6-465a-4154-a1b8-1a1bdf2d86da");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "36882a8b-7718-411d-aa72-cf0ff723c15e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "48fba63e-ce4c-43c4-97e6-0b48f1157369", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "864a906c-b319-4deb-87b6-ce123690bc53", 0, new DateOnly(2000, 1, 1), "07f05243-956a-41a5-bd40-5e952c8f2629", "admin@mail.com", false, 1, false, null, "Admin", "ADMIN@MAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEBfHkr7s/F2lHdsHPbU7oTwBHxyzcXXvUWyNgTCjCOJzi8yZjsjxc7hKW3/52nEm6w==", null, false, "6f7b8b61-182c-44d8-b4b3-cb683c8f1791", "Admin", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "48fba63e-ce4c-43c4-97e6-0b48f1157369", "864a906c-b319-4deb-87b6-ce123690bc53" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48fba63e-ce4c-43c4-97e6-0b48f1157369", "864a906c-b319-4deb-87b6-ce123690bc53" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48fba63e-ce4c-43c4-97e6-0b48f1157369");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "864a906c-b319-4deb-87b6-ce123690bc53");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "355bc4a6-465a-4154-a1b8-1a1bdf2d86da", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "36882a8b-7718-411d-aa72-cf0ff723c15e", 0, new DateOnly(2000, 1, 1), "4f136cad-2011-4285-a9ba-f2671299e95b", "admin@mail.com", false, 1, false, null, "Admin", "ADMIN@MAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEEga2BYGsV5NuNgIFIVKctMA4YwutGkLSpCXBYwon4giB8GL+I22tJJBTO8oeBOGLA==", null, false, "53e97543-a429-4cca-b922-32fd11302139", "Admin", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "355bc4a6-465a-4154-a1b8-1a1bdf2d86da", "36882a8b-7718-411d-aa72-cf0ff723c15e" });
        }
    }
}
