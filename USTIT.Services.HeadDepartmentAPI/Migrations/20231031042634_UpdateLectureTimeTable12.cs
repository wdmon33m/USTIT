using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace USTIT.Services.HeadDepartmentAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLectureTimeTable12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LectureTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartAt = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndAt = table.Column<TimeOnly>(type: "time", nullable: false),
                    NameArb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureTimes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LectureTimes",
                columns: new[] { "Id", "EndAt", "NameArb", "NameEng", "StartAt" },
                values: new object[,]
                {
                    { 1, new TimeOnly(10, 30, 0), "المحاضرة الأولى", "First Lecture", new TimeOnly(8, 30, 0) },
                    { 2, new TimeOnly(13, 0, 0), "المحاضرة الثانية", "Second Lecture", new TimeOnly(11, 0, 0) },
                    { 3, new TimeOnly(16, 0, 0), "المحاضرة الثالثة", "Third Lecture", new TimeOnly(14, 0, 0) },
                    { 4, new TimeOnly(18, 0, 0), "المحاضرة الرابعة", "Forth Lecture", new TimeOnly(16, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LectureTimes");
        }
    }
}
