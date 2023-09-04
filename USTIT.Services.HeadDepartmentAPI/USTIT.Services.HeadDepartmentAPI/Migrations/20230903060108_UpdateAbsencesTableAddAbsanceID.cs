using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USTIT.Services.HeadDepartmentAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAbsencesTableAddAbsanceID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Absences",
                columns: table => new
                {
                    AbsenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ANo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, computedColumnSql: "'A-' + CAST(StdGroupNo AS NVARCHAR(50)) + '-' + SUBSTRING(CENo, 13, LEN(CENo)) + '-' + CAST(ADate AS NVARCHAR(20))"),
                    ADate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CENo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StdGroupNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absences", x => x.AbsenceId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absences");
        }
    }
}
