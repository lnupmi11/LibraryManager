using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManager.DAL.Migrations
{
    public partial class droppingtestField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "testField",
                table: "Authors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "testField",
                table: "Authors",
                nullable: false,
                defaultValue: 0);
        }
    }
}
