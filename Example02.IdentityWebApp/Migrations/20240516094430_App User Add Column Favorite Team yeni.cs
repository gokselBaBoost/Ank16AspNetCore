using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example02.IdentityWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AppUserAddColumnFavoriteTeamyeni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Test",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "AspNetUsers");
        }
    }
}
