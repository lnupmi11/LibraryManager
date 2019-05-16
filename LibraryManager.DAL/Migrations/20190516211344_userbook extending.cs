using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManager.DAL.Migrations
{
    public partial class userbookextending : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInWishList",
                table: "UserBooks",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInWishList",
                table: "UserBooks");
        }
    }
}
