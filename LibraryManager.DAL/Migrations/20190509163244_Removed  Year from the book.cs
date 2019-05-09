using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManager.DAL.Migrations
{
    public partial class RemovedYearfromthebook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Books",
                nullable: false,
                defaultValue: 0);
        }
    }
}
