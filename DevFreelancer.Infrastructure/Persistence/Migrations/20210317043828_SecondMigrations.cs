using Microsoft.EntityFrameworkCore.Migrations;

namespace DevFreelancer.Infrastructure.Persistence.Migrations
{
    public partial class SecondMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSkills_Skills_SkillsId",
                table: "UserSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkills_Users_IdSkill",
                table: "UserSkills");

            migrationBuilder.DropIndex(
                name: "IX_UserSkills_SkillsId",
                table: "UserSkills");

            migrationBuilder.DropColumn(
                name: "SkillsId",
                table: "UserSkills");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_IdUser",
                table: "UserSkills",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkills_Skills_IdSkill",
                table: "UserSkills",
                column: "IdSkill",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkills_Users_IdUser",
                table: "UserSkills",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSkills_Skills_IdSkill",
                table: "UserSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkills_Users_IdUser",
                table: "UserSkills");

            migrationBuilder.DropIndex(
                name: "IX_UserSkills_IdUser",
                table: "UserSkills");

            migrationBuilder.AddColumn<int>(
                name: "SkillsId",
                table: "UserSkills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_SkillsId",
                table: "UserSkills",
                column: "SkillsId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkills_Skills_SkillsId",
                table: "UserSkills",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkills_Users_IdSkill",
                table: "UserSkills",
                column: "IdSkill",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
