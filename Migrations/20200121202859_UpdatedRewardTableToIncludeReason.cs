using Microsoft.EntityFrameworkCore.Migrations;

namespace RewardTrackerAPI.Migrations
{
    public partial class UpdatedRewardTableToIncludeReason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "RewardRecords",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reason",
                table: "RewardRecords");
        }
    }
}
