using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManager.DAL.Migrations
{
    public partial class userbookaddingisalreadyfinishedfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAlreadyFinished",
                table: "UserBooks",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAlreadyFinished",
                table: "UserBooks");
        }
    }
}
