using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManager.DAL.Migrations
{
    public partial class userbookisreading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRead",
                table: "UserBooks",
                newName: "IsReading");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsReading",
                table: "UserBooks",
                newName: "IsRead");
        }
    }
}
