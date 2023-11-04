using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USTIT.Services.HeadDepartmentAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDayOfWeek7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LectureSchedules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LectureSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CENo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LectureTimeId = table.Column<int>(type: "int", nullable: false),
                    StdGroupNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    HallNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LectureSchedules_CourseEnrollments_CENo",
                        column: x => x.CENo,
                        principalTable: "CourseEnrollments",
                        principalColumn: "CENo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LectureSchedules_LectureTimes_LectureTimeId",
                        column: x => x.LectureTimeId,
                        principalTable: "LectureTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LectureSchedules_StudentGroups_StdGroupNo",
                        column: x => x.StdGroupNo,
                        principalTable: "StudentGroups",
                        principalColumn: "StdGroupNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LectureSchedules_CENo",
                table: "LectureSchedules",
                column: "CENo");

            migrationBuilder.CreateIndex(
                name: "IX_LectureSchedules_LectureTimeId",
                table: "LectureSchedules",
                column: "LectureTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_LectureSchedules_StdGroupNo",
                table: "LectureSchedules",
                column: "StdGroupNo");
        }
    }
}
