using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USTIT.Services.HeadDepartmentAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDayOfWeek9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StdGroupNo",
                table: "LectureSchedules",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_LectureSchedules_StdGroupNo",
                table: "LectureSchedules",
                column: "StdGroupNo",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LectureSchedules_StudentGroups_StdGroupNo",
                table: "LectureSchedules",
                column: "StdGroupNo",
                principalTable: "StudentGroups",
                principalColumn: "StdGroupNo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LectureSchedules_StudentGroups_StdGroupNo",
                table: "LectureSchedules");

            migrationBuilder.DropIndex(
                name: "IX_LectureSchedules_StdGroupNo",
                table: "LectureSchedules");

            migrationBuilder.AlterColumn<string>(
                name: "StdGroupNo",
                table: "LectureSchedules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
