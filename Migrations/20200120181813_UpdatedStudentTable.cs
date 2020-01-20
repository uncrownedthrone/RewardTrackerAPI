using Microsoft.EntityFrameworkCore.Migrations;

namespace RewardTrackerAPI.Migrations
{
    public partial class UpdatedStudentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddReward",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RedeemReward",
                table: "Students",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddReward",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RedeemReward",
                table: "Students");
        }
    }
}
