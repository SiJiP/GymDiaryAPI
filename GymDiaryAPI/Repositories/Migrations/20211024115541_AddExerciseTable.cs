using Microsoft.EntityFrameworkCore.Migrations;

namespace GymDiaryAPI.Repositories.Migrations
{
    public partial class AddExerciseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Diaries_DiaryId",
                table: "Exercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise");

            migrationBuilder.RenameTable(
                name: "Exercise",
                newName: "Exercises");

            migrationBuilder.RenameIndex(
                name: "IX_Exercise_DiaryId",
                table: "Exercises",
                newName: "IX_Exercises_DiaryId");

            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "Exercises",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Diaries_DiaryId",
                table: "Exercises",
                column: "DiaryId",
                principalTable: "Diaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Diaries_DiaryId",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "Exercise");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_DiaryId",
                table: "Exercise",
                newName: "IX_Exercise_DiaryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Diaries_DiaryId",
                table: "Exercise",
                column: "DiaryId",
                principalTable: "Diaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
