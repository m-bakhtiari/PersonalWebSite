using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalCV.Core.Migrations
{
    public partial class SkillDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percent",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SkillDetailTitle",
                table: "Skills");

            migrationBuilder.CreateTable(
                name: "SkillDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    Percent = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillDetails_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillDetails_SkillId",
                table: "SkillDetails",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillDetails");

            migrationBuilder.AddColumn<int>(
                name: "Percent",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SkillDetailTitle",
                table: "Skills",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }
    }
}
