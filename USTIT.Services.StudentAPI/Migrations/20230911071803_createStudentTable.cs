using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USTIT.Services.StudentAPI.Migrations
{
    /// <inheritdoc />
    public partial class createStudentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    FullStdID = table.Column<string>(type: "nvarchar(450)", nullable: false, computedColumnSql: "CONVERT([nvarchar](50),(CONVERT([nvarchar](50),[AcYear],(0))+CONVERT([nvarchar](50),[DeptCode],(0)))+right('0000'+CONVERT([nvarchar](50),[StdNo],(0)),(4)),(0))", stored: true),
                    AcYear = table.Column<int>(type: "int", nullable: false),
                    DeptCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StdNo = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.FullStdID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
