using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USTIT.Services.StudentAPI.Migrations
{
    /// <inheritdoc />
    public partial class createStudentNamesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentNames",
                columns: table => new
                {
                    FullStdID = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    ArFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArSecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArThirdName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArFourthName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnSecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnThirdName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnFourthName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnFullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentNames", x => x.FullStdID);
                    table.ForeignKey(
                        name: "FK_StudentNames_Students_FullStdID",
                        column: x => x.FullStdID,
                        principalTable: "Students",
                        principalColumn: "FullStdID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentNames");
        }
    }
}
