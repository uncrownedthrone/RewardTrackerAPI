using Microsoft.EntityFrameworkCore.Migrations;

namespace RewardTrackerAPI.Migrations
{
    public partial class UpdatedTeacherTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Teachers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Teachers");
        }
    }
}
