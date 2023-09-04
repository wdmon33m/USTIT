using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USTIT.Services.HeadDepartmentAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateCETable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseEnrollments",
                columns: table => new
                {
                    CEId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CENo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, computedColumnSql: "CAST([DeptCode] AS NVARCHAR(10)) + '-' + CAST([AcYear] AS NVARCHAR(4)) + '-' + CAST([SemNo] AS NVARCHAR(2)) + '-' + CAST([CourseCode] AS NVARCHAR(50))"),
                    DeptCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassNo = table.Column<int>(type: "int", nullable: false),
                    SemNo = table.Column<int>(type: "int", nullable: false),
                    TeacherNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AcYear = table.Column<int>(type: "int", nullable: false),
                    LectureWeight = table.Column<int>(type: "int", nullable: false),
                    TutorialWeight = table.Column<int>(type: "int", nullable: false),
                    LabWeight = table.Column<int>(type: "int", nullable: false),
                    CourseWeight = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HasTutorial = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEnrollments", x => x.CEId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseEnrollments");
        }
    }
}
