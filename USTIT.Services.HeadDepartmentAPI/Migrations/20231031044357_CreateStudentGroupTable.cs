using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USTIT.Services.HeadDepartmentAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateStudentGroupTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentGroups",
                columns: table => new
                {
                    StdGroupNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeptCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcYear = table.Column<int>(type: "int", nullable: false),
                    ClassNo = table.Column<int>(type: "int", nullable: false),
                    SemNo = table.Column<int>(type: "int", nullable: false),
                    StdCount = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromStd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToStd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGroups", x => x.StdGroupNo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentGroups");
        }
    }
}
