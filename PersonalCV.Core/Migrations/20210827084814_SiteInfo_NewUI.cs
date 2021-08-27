using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalCV.Core.Migrations
{
    public partial class SiteInfo_NewUI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Key",
                value: 13);

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Key",
                value: 14);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Key",
                value: 20);

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Key",
                value: 21);
        }
    }
}
