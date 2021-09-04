using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalCV.Core.Migrations
{
    public partial class Description_HostPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BandwidthPerMonth",
                table: "HostPlans");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "HostPlans");

            migrationBuilder.DropColumn(
                name: "ExtraWebSite",
                table: "HostPlans");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "HostPlans",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "HostPlans");

            migrationBuilder.AddColumn<int>(
                name: "BandwidthPerMonth",
                table: "HostPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "HostPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExtraWebSite",
                table: "HostPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
