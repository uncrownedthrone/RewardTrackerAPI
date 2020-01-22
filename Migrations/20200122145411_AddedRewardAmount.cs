using Microsoft.EntityFrameworkCore.Migrations;

namespace RewardTrackerAPI.Migrations
{
    public partial class AddedRewardAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RewardAmount",
                table: "RewardRecords",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RewardAmount",
                table: "RewardRecords");
        }
    }
}
