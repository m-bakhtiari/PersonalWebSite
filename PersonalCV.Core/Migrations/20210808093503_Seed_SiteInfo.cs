using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalCV.Core.Migrations
{
    public partial class Seed_SiteInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SiteInfos",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[] { 1, 20, "Mohammadev@gmail.com" });

            migrationBuilder.InsertData(
                table: "SiteInfos",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[] { 2, 21, "MamaliDev871374" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
