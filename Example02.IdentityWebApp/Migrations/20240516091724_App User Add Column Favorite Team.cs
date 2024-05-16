using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example02.IdentityWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AppUserAddColumnFavoriteTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "FavoriteTeam",
                table: "AspNetUsers",
                type: "tinyint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoriteTeam",
                table: "AspNetUsers");
        }
    }
}
