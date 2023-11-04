using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USTIT.Services.HeadDepartmentAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDayOfWeek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "LectureSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "LectureSchedules");
        }
    }
}
