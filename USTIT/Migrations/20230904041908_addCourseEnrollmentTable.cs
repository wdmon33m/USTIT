using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace USTIT.Services.BasicDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class addCourseEnrollmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicDegrees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicDegreeArb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademicDegreeEng = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicDegrees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseCode);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    TeacherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AcademicDegreeID = table.Column<int>(type: "int", nullable: false),
                    IsLecturer = table.Column<bool>(type: "bit", nullable: false),
                    IsTeacherAssistant = table.Column<bool>(type: "bit", nullable: false),
                    IsCollaborator = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherNo);
                    table.ForeignKey(
                        name: "FK_Teachers_AcademicDegrees_AcademicDegreeID",
                        column: x => x.AcademicDegreeID,
                        principalTable: "AcademicDegrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseEnrollments",
                columns: table => new
                {
                    CENo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DeptCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_CourseEnrollments", x => x.CENo);
                    table.ForeignKey(
                        name: "FK_CourseEnrollments_Teachers_TeacherNo",
                        column: x => x.TeacherNo,
                        principalTable: "Teachers",
                        principalColumn: "TeacherNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AcademicDegrees",
                columns: new[] { "Id", "AcademicDegreeArb", "AcademicDegreeEng" },
                values: new object[,]
                {
                    { 1, "بروفيسور", "Professor" },
                    { 2, "دكتور", "Doctor" },
                    { 3, "ماجستير", "Master's" },
                    { 4, "بكلاريوس", "Bachelor's" },
                    { 5, "دبلوم", "Diploma" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrollments_TeacherNo",
                table: "CourseEnrollments",
                column: "TeacherNo");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_AcademicDegreeID",
                table: "Teachers",
                column: "AcademicDegreeID");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_TeacherName",
                table: "Teachers",
                column: "TeacherName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseEnrollments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "AcademicDegrees");
        }
    }
}
