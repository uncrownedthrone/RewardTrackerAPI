using Microsoft.EntityFrameworkCore.Migrations;

namespace RewardTrackerAPI.Migrations
{
    public partial class AddedPeriodSubjectClassroomTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Classrooms");

            migrationBuilder.AddColumn<int>(
                name: "PeriodNumber",
                table: "Classrooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Classrooms",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodNumber",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Classrooms");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Classrooms",
                type: "text",
                nullable: true);
        }
    }
}
